<template>
    <div style="margin-left: 25px">
        <div style="float: right">
            <el-button type="primary" @click="add">添加</el-button>
        </div>
        <el-table :data="tableData">
            <el-table-column
                    label="ID"
                    width="80">
                <template slot-scope="scope">
                    <span>{{ scope.row.appConfigId }}</span>
                </template>
            </el-table-column>
            <el-table-column
                    label="名称"
                    width="180">
                <template slot-scope="scope">
                    <el-popover trigger="hover" placement="top">
                        <p>解决方案ID: {{ scope.row.solutionID }}</p>
                        <p>程序配置版本: {{ scope.row.version }}</p>
                        <p>解决方案根配置: {{ scope.row.configContent }}</p>
                        <div slot="reference" class="name-wrapper">
                            <el-tag size="medium">{{ scope.row.solutionName }}</el-tag>
                        </div>
                    </el-popover>
                </template>
            </el-table-column>
            <el-table-column
                    label="创建时间"
                    width="160">
                <template slot-scope="scope">
                    <span>{{ scope.row.createTime }}</span>
                </template>
            </el-table-column>
            <el-table-column
                    label="更新时间"
                    width="160">
                <template slot-scope="scope">
                    <span>{{ scope.row.updateTime }}</span>
                </template>
            </el-table-column>
            <el-table-column label="操作">
                <template slot-scope="scope">
                    <el-button size="mini" @click="edit(scope.row.appConfigId)">编辑</el-button>
                    <el-button size="mini" @click="editConfig(scope.row.appConfigId)">管理组件配置</el-button>
                    <el-button size="mini" type="danger" @click="del(scope.row.appConfigId)">删除</el-button>
                </template>
            </el-table-column>
        </el-table>
        <div style="float: right" v-show="pagerData.totalPage>0">
            <el-pagination
                    @current-change="getPager"
                    layout="prev, pager, next"
                    :total="pagerData.totalPage">
            </el-pagination>
        </div>
    </div>
</template>

<script>
    import httphelper from '../../util/httphelper'
    import urls from '../../urlstatic'

    export default {
        name: "AppConfigList",
        created: function () {
            this.appId=this.$route.params.id;
            this.getPager(1);
        },
        data: function () {
            return {
                appId:0,
                pagerData: {
                    totalPage: 0
                },
                tableData: []
            }
        },
        methods: {
            getPager: function(page) {
                var that = this;
                httphelper.authedpostform(urls.appConfigPagerUrl, {"page": page, "size": 10,"appId":that.appId},
                    function (data) {
                        that.tableData = data.data;
                        that.pagerData.totalPage = data.total / data.pageSize;
                        if (that.pagerData.totalPage < 1) {
                            that.pagerData.totalPage = 1;
                        }
                    })
            },
            back: function(){

            },
            add: function() {
                this.$router.push("/home/appconfigedit/"+this.appId);
            },
            edit: function(id) {
                this.$router.push("/home/appconfigedit/" +this.appId+"/"+ id);
            },
            editConfig: function(id){
                this.$router.push("/home/appcomponentconfiglist/" +this.appId+"/"+ id);
            },
            del: function(id) {
                var that = this;
                httphelper.authedpostform(urls.appConfigDeleteUrl, {"id": id},
                    function (data) {
                        if(data)
                            that.$notify.success("操作成功");
                    });
            }
        }
    }
</script>

<style scoped>

</style>