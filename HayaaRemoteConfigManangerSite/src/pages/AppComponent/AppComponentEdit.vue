<template>
    <div style="width: 800px;margin-left: 15%">
        <el-form :model="ruleForm" :rules="rules" ref="ruleForm" label-width="100px" class="demo-ruleForm">
            <el-form-item label="类名称" prop="componentServiceName">
                <el-input v-model="ruleForm.componentServiceName" style="width:320px"></el-input>
            </el-form-item>
            <el-form-item label="类全名" prop="componentServiceCompeleteName">
                <el-input type="textarea" :rows="2" v-model="ruleForm.componentServiceCompeleteName"
                          placeholder="类名,程序集名,Version=1.0.0,Culture=neutral,PublicKeyToken=null"></el-input>
            </el-form-item>
            <el-form-item label="接口列表" prop="componentInterface">
                <el-input v-model="ruleForm.componentInterface" placeholder="形式:接口1,接口2"></el-input>
            </el-form-item>
            <el-form-item label="程序集名称" prop="componentAssemblyName">
                <el-input v-model="ruleForm.componentAssemblyName" style="width:320px"></el-input>
            </el-form-item>
            <el-form-item label="程序集文件名" prop="componentAssemblyFileName">
                <el-input v-model="ruleForm.componentAssemblyFileName" style="width:320px"></el-input>
            </el-form-item>
            <el-form-item label="程序集路径" prop="componentAssemblyFileStorePath">
                <el-input v-model="ruleForm.componentAssemblyFileStorePath"></el-input>
            </el-form-item>
            <el-form-item label="程序集版本" prop="assemblyVersion">
                <el-input v-model="ruleForm.assemblyVersion" placeholder="1.0.0.0" style="width:100px"></el-input>
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
        data: function() {
            return {
                ruleForm: {
                    appComponentId: 0,
                    componentId: 0,
                    componentServiceName: '',
                    componentServiceCompeleteName: '',
                    componentAssemblyFileName: '',
                    componentAssemblyFileStorePath: '',
                    componentAssemblyName: '',
                    assemblyVersion: '1.0.0.0',
                    componentInterface: ""
                },
                rules: {
                    componentInterface: [
                        {required: true, message: '请输入接口列表', trigger: 'blur'}
                    ],
                    componentId: [
                        {required: true, message: '请输入合法组件Id', trigger: 'blur'}
                    ],
                    componentServiceCompeleteName: [
                        {required: true, message: '请输入类全名', trigger: 'blur'},
                        {min: 15, max: 500, message: '长度在 15 到 500 个字符', trigger: 'blur'}
                    ],
                    componentServiceName: [
                        {required: true, message: '请输入类名称', trigger: 'blur'},
                        {min: 1, max: 200, message: '长度在 1 到 200 个字符', trigger: 'blur'}
                    ],
                    componentAssemblyName: [
                        {required: true, message: '请输入程序集名', trigger: 'blur'},
                        {min: 1, max: 300, message: '长度在 1 到 300 个字符', trigger: 'blur'}
                    ],
                    componentAssemblyFileName: [
                        {required: false, message: '请输入程序集文件名', trigger: 'blur'},
                        {min: 1, max: 300, message: '长度在 1 到 300 个字符', trigger: 'blur'}
                    ],
                    componentAssemblyFileStorePath: [
                        {required: false, message: '请输入程序集存储路径', trigger: 'blur'},
                        {min: 1, max: 1000, message: '长度在 1 到 1000 个字符', trigger: 'blur'}
                    ],
                    assemblyVersion: [
                        {required: false, message: '请输入程序集版本', trigger: 'blur'},
                        {min: 1, max: 100, message: '长度在 1 到 100 个字符', trigger: 'blur'}
                    ],
                }
            };
        },
        created: function () {
             this.ruleForm.componentId = this.$route.params.cid;
            if(this.$route.params.id)
                this.ruleForm.appComponentId = this.$route.params.id;
            if (this.ruleForm.appComponentId) {
                this.get(this.ruleForm.appComponentId);
            }
        },
        methods: {
            back: function() {
                this.$router.push("/home/appcomponentlist/"+this.ruleForm.componentId);
            },
            get: function(id) {
                var that = this;
                httphelper.authedpostform(urls.appComponentGetUrl, {"id": id},
                    function (data) {
                        that.ruleForm = data;
                    });
            },
            submitForm: function(formName) {
                var that = this;
                this.$refs[formName].validate(function(valid) {
                    if (valid) {
                        if (that.ruleForm.appComponentId == 0) {
                            httphelper.authedpostform(urls.appComponentAddUrl, that.ruleForm,
                                function (data) {
                                    that.back();
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
            resetForm: function(formName) {
                this.$refs[formName].resetFields();
            }
        }
    }
</script>

<style scoped>

</style>