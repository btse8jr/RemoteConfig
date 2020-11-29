<template>
    <div style="width: 500px;margin-left: 15%">
        <el-form :model="ruleForm" :rules="rules" ref="ruleForm" label-width="120px" class="demo-ruleForm">
            <el-form-item label="程序ID" prop="appId">
                <el-input v-model="ruleForm.appId" style="width: 100px" disabled></el-input>
            </el-form-item>
            <el-form-item label="解决方案ID" prop="solutionID">
                <el-input v-model="ruleForm.solutionID"></el-input>
            </el-form-item>
            <el-form-item label="解决方案名称" prop="solutionName">
                <el-input v-model="ruleForm.solutionName"></el-input>
            </el-form-item>
            <el-form-item label="解决方案根配置">
                <el-input type="textarea" :rows="6" v-model="ruleForm.configContent"></el-input>
            </el-form-item>
            <!--<el-form-item label="程序配置版本" prop="version">-->
                <!--<el-input v-model="ruleForm.version" style="width: 100px"></el-input>-->
            <!--</el-form-item>-->
            <el-form-item>
                <el-button type="primary" @click="submitForm('ruleForm')">提交</el-button>
                <el-button @click="resetForm('ruleForm')">重置</el-button>
                <el-button @click="back">返回</el-button>
            </el-form-item>
        </el-form>
    </div>
</template>

<script>
    import httphelper from '../../util/httphelper'
    import urls from '../../urlstatic'

    export default {
        name: "AppConfigEdit",
        data() {
            return {
                ruleForm: {
                    appConfigId: 0,
                    appId:0,
                    solutionID:"",
                    solutionName:"",
                    configContent:"",
                    version:1
                },
                rules: {
                    appId: [
                        {required: true, message: '请输入程序ID', trigger: 'blur'}
                    ],
                    solutionID: [
                        {required: true, message: '请输入解决方案ID', trigger: 'blur'},
                        {min: 32, max: 128, message: '长度在 32 到 128 个字符', trigger: 'blur'}
                    ],
                    solutionName: [
                        {required: true, message: '请输入解决方案名称', trigger: 'blur'},
                        {min: 1, max: 100, message: '长度在 1 到 100 个字符', trigger: 'blur'}
                    ],
                    // version: [
                    //     {required: true, message: '请输入程序配置版本', trigger: 'blur'}
                    // ]
                }
            };
        },
        created: function () {
            this.ruleForm.appId = this.$route.params.aid;
            if(this.$route.params.id)
                this.ruleForm.appConfigId = this.$route.params.id;
            if (this.ruleForm.appConfigId>0){
                this.get(this.ruleForm.appConfigId);
            }
        },
        methods: {
            back() {
                this.$router.push("/home/appconfiglist/"+this.ruleForm.appId);
            },
            get(id) {
                var that = this;
                httphelper.authedpostform(urls.appConfigGetUrl, {"id": id},
                    function (data) {
                        that.ruleForm = data;
                    });
            },
            submitForm(formName) {
                var that = this;
                this.$refs[formName].validate((valid) => {
                    if (valid) {
                        if (that.ruleForm.appConfigId == 0) {
                            httphelper.authedpostform(urls.appConfigAddUrl, that.ruleForm,
                                function (data) {
                                    that.ruleForm = data;
                                    that.$notify.success("操作成功");
                                    that.back();
                                });
                        } else {
                            httphelper.authedpostform(urls.appConfigEditUrl, that.ruleForm,
                                function (data) {
                                    if (data)
                                        that.$notify.success("操作成功");
                                });
                        }
                    } else {
                        return false;
                    }
                });
            },
            resetForm(formName) {
                this.$refs[formName].resetFields();
            }
        }
    }
</script>

<style scoped>

</style>