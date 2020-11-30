<template>
    <div style="margin-left: 25px">
        <div style="float: right">
            <el-button type="primary" @click="add" v-show="(componentId!=10002)">添加</el-button>
        </div>
        <el-table :data="tableData">
            <el-table-column
                    label="ID"
                    width="80">
                <template slot-scope="scope">
                    <span>{{ scope.row.componentConfigId }}</span>
                </template>
            </el-table-column>
            <el-table-column
                    label="名称"
                    width="240">
                <template slot-scope="scope">
                    <el-popover trigger="hover" placement="top">
                        <p>组件ID: {{ scope.row.componentId }}</p>
                        <p>配置版本: {{ scope.row.version }}</p>
                        <div style="width: 300px;overflow: auto">配置: {{ scope.row.content }}</div>
                        <p>是否组件默认配置: <span v-if="scope.row.isDefault">是</span><span v-else>否</span></p>
                        <div slot="reference" class="name-wrapper">
                            <el-tag size="medium">{{ scope.row.componentConfigTitle }}</el-tag>
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
                    <el-button size="mini" @click="edit(scope.row.componentConfigId)">编辑</el-button>
                    <el-button size="mini" type="danger" @click="del(scope.row.componentConfigId)">删除</el-button>
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
        name: "ComponentConfigList",
        created: function () {
            this.componentId=this.$route.params.id;
            this.getPager(1);
        },
        data: function () {
            return {
                componentId:0,
                pagerData: {
                    totalPage: 0
                },
                tableData: []
            }
        },
        methods: {
            getPager: function(page) {
                var that = this;
                httphelper.authedpostform(urls.componentConfigPagerUrl, {"page": page, "size": 10,"componentId":that.componentId},
                    function (data) {
                        that.tableData = data.data;
                        that.pagerData.totalPage = data.total / data.pageSize;
                        if (that.pagerData.totalPage < 1) {
                            that.pagerData.totalPage = 1;
                        }
                    })
            },
            add: function() {
                this.$router.push("/home/componentconfigedit/"+this.componentId);
            },
            edit: function(id) {
                this.$router.push("/home/componentconfigedit/"+this.componentId+"/" + id);
            },
            del: function(id) {
                var that = this;
                httphelper.authedpostform(urls.componentConfigDeleteUrl, {"id": id},
                    function (data) {
                        if(data) {
                            that.$notify.success("操作成功");
                            that.getPager(1);
                        }
                    });
            }
        }
    }
</script>

<style scoped>

</style>