<template>
    <div style="width: 400px;margin-left: 15%">
        <el-form :model="ruleForm" :rules="rules" ref="ruleForm" label-width="100px" class="demo-ruleForm">
            <el-form-item label="类名称" prop="ComponentServiceName">
                <el-input v-model="ruleForm.componentServiceName"></el-input>
            </el-form-item>
            <el-form-item label="类全名" prop="ComponentServiceCompeleteName">
                <el-input v-model="ruleForm.componentServiceCompeleteName" placeholder="类名, 程序集名, Version=1.0.0, Culture=neutral, PublicKeyToken=null"></el-input>
            </el-form-item>
            <el-form-item label="程序集名称" prop="ComponentAssemblyName">
                <el-input v-model="ruleForm.componentAssemblyName"></el-input>
            </el-form-item>
            <el-form-item label="程序集文件名" prop="ComponentAssemblyFileName">
                <el-input v-model="ruleForm.componentAssemblyFileName"></el-input>
            </el-form-item>
            <el-form-item label="程序集路径" prop="ComponentAssemblyFileStorePath">
                <el-input v-model="ruleForm.componentAssemblyFileStorePath"></el-input>
            </el-form-item>
            <el-form-item label="程序集版本" prop="AssemblyVersion">
                <el-input v-model="ruleForm.assemblyVersion"  placeholder="1.0.0.0"></el-input>
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
        name: "AppComponentEdit",
        data() {
            return {
                ruleForm: {
                    appComponentId: 0,
                    componentServiceName: '',
                    componentServiceCompeleteName: '',
                    componentAssemblyFileName: '',
                    componentAssemblyFileStorePath: '',
                    componentAssemblyName: '',
                    assemblyVersion: ''
                },
                rules: {
                    ComponentServiceCompeleteName: [
                        {required: true, message: '请输入类全名', trigger: 'blur'},
                        {min: 15, max: 500, message: '长度在 15 到 500 个字符', trigger: 'blur'}
                    ],
                    ComponentServiceName: [
                        {required: true, message: '请输入类名称', trigger: 'blur'},
                        {min: 1, max: 200, message: '长度在 1 到 200 个字符', trigger: 'blur'}
                    ],
                    ComponentAssemblyName: [
                        {required: true, message: '请输入程序集名', trigger: 'blur'},
                        {min: 1, max: 300, message: '长度在 1 到 300 个字符', trigger: 'blur'}
                    ],
                    ComponentAssemblyFileName: [
                        {required: false, message: '请输入程序集文件名', trigger: 'blur'},
                        {min: 1, max: 300, message: '长度在 1 到 300 个字符', trigger: 'blur'}
                    ],
                    ComponentAssemblyFileStorePath: [
                        {required: false, message: '请输入程序集存储路径', trigger: 'blur'},
                        {min: 1, max: 1000, message: '长度在 1 到 1000 个字符', trigger: 'blur'}
                    ],
                    AssemblyVersion: [
                        {required: false, message: '请输入程序集版本', trigger: 'blur'},
                        {min: 1, max: 100, message: '长度在 1 到 100 个字符', trigger: 'blur'}
                    ],
                }
            };
        },
        created: function () {
            var id = this.$route.params.id;
            if (id&(id>0)) {
                this.get(id);
            }
        },
        methods: {
            back() {
                this.$router.push("/home/appcomponentlist");
            },
            get(id) {
                var that = this;
                httphelper.authedpostform(urls.appComponentGetUrl, {"id": id},
                    function (data) {
                        that.ruleForm = data;
                    });
            },
            submitForm(formName) {
                var that = this;
                this.$refs[formName].validate((valid) => {
                    if (valid) {
                        if (that.ruleForm.AppId == 0) {
                            httphelper.authedpostform(urls.appComponentAddUrl, that.ruleForm,
                                function (data) {
                                    that.ruleForm = data;
                                    that.$notify.success("操作成功");
                                });
                        } else {
                            httphelper.authedpostform(urls.appComponentEditUrl, that.ruleForm,
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