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
                    <span>{{ scope.row.appComponentId }}</span>
                </template>
            </el-table-column>
            <el-table-column
                    label="组件ID"
                    width="80">
                <template slot-scope="scope">
                    <span>{{ scope.row.componentId }}</span>
                </template>
            </el-table-column>
            <el-table-column
                    label="服务类名称"
                    width="300px">
                <template slot-scope="scope">
                    <el-popover trigger="hover" placement="top">
                        <p>类全名: {{ scope.row.componentServiceCompeleteName }}</p>
                        <p>程序集名: {{ scope.row.componentAssemblyName }}</p>
                        <p>程序集文件名: {{ scope.row.componentAssemblyFileName }}</p>
                        <p>程序集存储路径: {{ scope.row.componentAssemblyFileStorePath }}</p>
                        <p>程序集版本: {{ scope.row.assemblyVersion }}</p>
                        <div slot="reference" class="name-wrapper">
                            <el-tag size="medium">{{ scope.row.componentServiceName }}</el-tag>
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
                    <el-button size="mini" @click="edit(scope.row.appComponentId)">编辑</el-button>
                    <el-button size="mini" type="danger" @click="del(scope.row.appComponentId)">删除</el-button>
                </template>
            </el-table-column>
        </el-table>
        <div style="float: right" v-show="pagerData.total>0">
            <el-pagination
                    @current-change="getPager"
                    layout="prev, pager, next"
                    :page-size="pagerData.size"
                    :total="pagerData.total">
            </el-pagination>
        </div>
    </div>
</template>

<script>
    import httphelper from '../../util/httphelper'
    import urls from '../../urlstatic'

    export default {
        name: "AppComponentList",
        created: function () {
            this.componentId=this.$route.params.id;
            this.getPager(1);
        },
        data: function () {
            return {
                componentId:0,
                pagerData: {
                    total: 0,
                    size:5
                },
                tableData: []
            }
        },
        methods: {
            getPager: function(page) {
                var that = this;
                httphelper.authedpostform(urls.appComponentPagerUrl, {"page": page, "size": 5,"componentId":that.componentId},
                    function (data) {
                        that.tableData = data.data;
                        that.pagerData.total =data.total;
                    })
            },
            add: function() {
                this.$router.push("/home/appcomponentedit/"+this.componentId);
            },
            edit: function(id) {
                this.$router.push("/home/appcomponentedit/" +this.componentId+"/"+ id);
            },
            del: function(id) {
                var that = this;
                httphelper.authedpostform(urls.appComponentDeleteUrl, {"id": id},
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