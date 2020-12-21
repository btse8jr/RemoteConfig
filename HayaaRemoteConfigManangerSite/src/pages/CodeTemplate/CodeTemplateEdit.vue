<template>
    <div style="width: 400px;margin-left: 15%">
        <el-form :model="ruleForm" :rules="rules" ref="ruleForm" label-width="100px" class="demo-ruleForm">
            <el-form-item label="名称" prop="name">
                <el-input v-model="ruleForm.name"></el-input>
            </el-form-item>
            <el-form-item label="可见名称" prop="title">
                <el-input v-model="ruleForm.spaceName"></el-input>
            </el-form-item>
            <el-form-item label="语言类型">
                <el-select v-model="ruleForm.language" placeholder="请选择语言类型">
                    <el-option v-for="item in languageData" :key="item.title"
                               :label="item.title"
                               :value="item.value"></el-option>
                </el-select>
            </el-form-item>
            <el-form-item label="代码类型">
                <el-select v-model="ruleForm.genCodeType" placeholder="请选择代码类型">
                    <el-option label="DataAccessModel" value="1"></el-option>
                    <el-option label="Dao" value="2"></el-option>
                    <el-option label="Service" value="4"></el-option>
                    <el-option label="ViewService" value="8"></el-option>
                    <el-option label="ClientService" value="16"></el-option>
                    <el-option label="ClientView" value="32"></el-option>
                </el-select>
            </el-form-item>
            <el-form-item label="模板" prop="content">
                <el-input type="textarea" :rows="8" v-model="ruleForm.content"></el-input>
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
        name: "CodeTemplateEdit",
        data: function() {
            return {
                solutionTemplateId:0,
                ruleForm: {
                    codeTemplateId: 0,
                    title: '',
                    name: '',
                    spaceName:"",
                    genCodeType:1,
                    language:1
                },
                languageData:[
                    {title:"CSharp",value:1},
                    {title:"Java",value:2},
                    {title:"FSharp",value:4},
                    {title:"Go",value:8},
                    {title:"Python",value:16},
                    {title:"Html",value:128},
                    {title:"Javascript",value:256}
                ],
                rules: {
                    name: [
                        {required: true, message: '请输入名称', trigger: 'blur'},
                        {min: 1, max: 50, message: '长度在 1 到 50 个字符', trigger: 'blur'}
                    ],
                    title: [
                        {required: false, message: '请输入可见名称', trigger: 'blur'},
                        {min: 1, max: 50, message: '长度在 1 到 50 个字符', trigger: 'blur'}
                    ]

                }
            };
        },
        created: function () {
            var id = this.$route.params.id;
            this.solutionTemplateId= this.$route.params.sid;
            if (id>0) {
                this.get(id);
            }
        },
        methods: {
            back: function() {
                var that = this;
                this.$router.push("/home/codetemplatelist/"+that.solutionTemplateId);
            },
            get: function(id) {
                var that = this;
                httphelper.authedpostform(urls.codeTemplateGetUrl, {"id": id},
                    function (data) {
                        that.ruleForm = data;
                    });
            },
            submitForm: function(formName) {
                var that = this;
                this.$refs[formName].validate(function(valid) {
                    if (valid) {
                        if (that.ruleForm.codeTemplateId == 0) {
                            httphelper.authedpostform(urls.codeTemplateAddUrl, that.ruleForm,
                                function (data) {
                                    that.back();
                                });
                        } else {
                            httphelper.authedpostform(urls.codeTemplateEditUrl, that.ruleForm,
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