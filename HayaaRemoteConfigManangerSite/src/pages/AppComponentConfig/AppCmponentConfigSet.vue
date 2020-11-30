<template>
    <div style="width: 400px;margin-left: 15%">
        <el-form :model="ruleForm" :rules="rules" ref="ruleForm" label-width="100px" class="demo-ruleForm">
            <el-form-item label="程序ID" prop="appId">
                <el-input v-model="ruleForm.appId" disabled></el-input>
            </el-form-item>
            <el-form-item label="组件ID" prop="componentId">
                <el-input v-model="ruleForm.componentId" disabled></el-input>
            </el-form-item>
            <el-form-item label="执行用户ID" prop="appUserId">
                <el-input v-model="ruleForm.appUserId"></el-input>
            </el-form-item>
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
        name: "AppCmponentConfigSet",
        data: function() {
            return {
                appConfigId: 0,
                ruleForm: {
                    appId: 0,
                    componentId: 0,
                    appUserId: 0
                },
                rules: {
                    componentId: [
                        {required: true, message: '请输入组件ID', trigger: 'blur'}
                    ],
                    appUserId: [
                        {required: true, message: '请输入执行用户ID', trigger: 'blur'}
                    ]

                }
            };
        },
        created: function () {
            this.ruleForm.appId = this.$route.params.aid;
            this.ruleForm.componentId = this.$route.params.cid;
            this.appConfigId = this.$route.params.afid;

        },
        methods: {
            back: function() {
                this.$router.push("/home/appcomponentconfiglist/" + this.ruleForm.appId + "/" + this.appConfigId);
            },
            submitForm: function (formName) {
                var that = this;
                this.$refs[formName].validate(function(valid) {
                    if (valid) {
                        httphelper.authedpostform(urls.appComponentFactoryCreateUrl, that.ruleForm,
                            function (data) {
                                that.back();
                            });
                    } else {
                        return false;
                    }
                });
            },
            resetForm: function(formName) {
                this.$refs[formName].resetFields();
            }
        }
    }
</script>

<style scoped>

</style>