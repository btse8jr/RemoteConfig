<template>
    <div style="width: 750px;margin-left: 15%">
        <el-form :model="ruleForm" :rules="rules" ref="ruleForm" label-width="100px" class="demo-ruleForm">
            <el-form-item label="名称" prop="componentConfigTitle">
                <el-input v-model="ruleForm.componentConfigTitle" style="width: 300px"></el-input>
            </el-form-item>
            <el-form-item label="配置内容" prop="content">
                <el-input type="textarea" :rows="8" v-model="ruleForm.content"></el-input>
            </el-form-item>
            <!--<el-form-item label="配置版本" prop="version">-->
                <!--<el-input v-model="ruleForm.version" style="width: 100px"></el-input>-->
            <!--</el-form-item>-->
            <el-form-item label="默认配置">
                <el-switch v-model="ruleForm.IsDefault" active-color="#13ce66" inactive-color="#ff4949"></el-switch>
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
        name: "ComponentConfigEdit",
        data() {
            return {
                ruleForm: {
                    componentConfigId: 0,
                    componentId:0,
                    content:"",
                    version:1,
                    componentConfigTitle: '',
                    IsDefault: false
                },
                rules: {
                    content: [
                        {required: true, message: '请输入配置内容', trigger: 'blur'}
                    ],
                    componentConfigTitle: [
                        {required: true, message: '请输入可见名称', trigger: 'blur'},
                        {min: 1, max: 100, message: '长度在 1 到 100 个字符', trigger: 'blur'}
                    ]

                }
            };
        },
        created: function () {
            this.ruleForm.componentId = this.$route.params.cid;
            if(this.$route.params.id)
            this.ruleForm.componentConfigId = this.$route.params.id;
            if (this.ruleForm.componentConfigId>0) {
                this.get(this.this.ruleForm.componentConfigId);
            }
        },
        methods: {
            back: function() {
                this.$router.push("/home/componentconfiglist/"+this.ruleForm.componentId);
            },
            get: function(id) {
                var that = this;
                httphelper.authedpostform(urls.componentConfigGetUrl, {"id": id},
                    function (data) {
                        that.ruleForm = data;
                    });
            },
            submitForm: function(formName) {
                var that = this;
                this.$refs[formName].validate((valid) => {
                    if (valid) {
                        if (that.ruleForm.componentConfigId == 0) {
                            httphelper.authedpostform(urls.componentConfigAddUrl, that.ruleForm,
                                function (data) {
                                    that.ruleForm = data;
                                    that.back();
                                });
                        } else {
                            httphelper.authedpostform(urls.componentConfigEditUrl, that.ruleForm,
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
            resetForm: function(formName) {
                this.$refs[formName].resetFields();
            }
        }
    }
</script>

<style scoped>

</style>