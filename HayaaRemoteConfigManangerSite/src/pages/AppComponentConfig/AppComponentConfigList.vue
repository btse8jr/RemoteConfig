<template>
    <div style="margin-left: 25px">
        <div style="float: left;width: 600px;">
            <el-input v-model="componentConfigId" style="width: 80px" size="mini"></el-input>
            <el-button type="primary" @click="add" size="mini">添加</el-button>

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
                    width="180">
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
                    <el-button size="mini" @click="setFactoryConfig(scope.row.componentId)"
                               v-show="scope.row.componentId!=10002">设置服务工厂数据
                    </el-button>
                    <el-button size="mini" type="danger" @click="del(scope.row.componentConfigId)">删除</el-button>
                </template>
            </el-table-column>
        </el-table>
        <div style="float: right;margin-top: 10px">
            <el-button type="primary" @click="createFactoryConfig">生成服务工厂数据</el-button>
            <el-button @click="back">返回</el-button>
        </div>
    </div>
</template>

<script>
    import httphelper from '../../util/httphelper'
    import urls from '../../urlstatic'

    export default {
        name: "ComponentConfigList",
        created: function () {
            this.appConfigId = this.$route.params.id;
            this.appId = this.$route.params.aid;
            this.getPager();
        },
        data: function () {
            return {
                appConfigId: 0,
                appId: 0,
                componentConfigId: 0,
                componentConfigId_10002: 0,
                pagerData: {
                    totalPage: 0
                },
                tableData: [],
                appComponentData: []
            }
        },
        methods: {
            getPager: function() {
                var that = this;
                httphelper.authedpostform(urls.componentConfigGetListUrl, {
                        "version": 1,
                        "appConfigId": that.appConfigId
                    },
                    function (data) {
                        that.tableData = data;
                        that.loadAppComponentData();
                    })
            },
            loadAppComponentData: function() {
                var that = this;
                that.appComponentData = [];
                for (var c in that.tableData) {
                    if (that.tableData[c].componentId == 10002) that.componentConfigId_10002 = that.tableData[c].componentConfigId;
                    httphelper.authedpostform(urls.appComponentGetListUrl, {
                            "appId": that.appId,
                            "componentId": that.tableData[c].componentId
                        },
                        function (data) {
                            for (var i in data) {
                                that.appComponentData.push(data[i])
                            }
                        });
                }
            },
            createFactoryConfig: function() {
                var that = this;
                if (that.componentConfigId_10002 > 0) {
                    that.Remove10002Config(function () {
                        that.create10002Config(that.appComponentData);
                    });
                } else
                    that.create10002Config(that.appComponentData);
            },
            create10002Config: function(info) {
                var that = this;
                httphelper.authedpostform(urls.componentConfigAddUrl, {
                        "ComponentConfigTitle": "10002-程序" + that.appId + "的功能服务工厂配置",
                        "ComponentId": 10002,
                        "Version": 1,
                        "Content": JSON.stringify(info),
                        "IsDefault": false
                    },
                    function (data) {
                        that.addComponentConfig(data.componentConfigId);
                    });
            },
            addComponentConfig: function(componentConfigId) {
                var that = this;
                httphelper.authedpostform(urls.appConfigAddComponentConfigUrl, {
                        "appConfigId": that.appConfigId,
                        "componentConfigId": componentConfigId
                    },
                    function (data) {
                        if (data) {
                            that.getPager();
                        }
                    });
            },
            setFactoryConfig: function(componentId) {
                this.$router.push("/home/appcomponentconfigset/" + this.appId + "/" + componentId + "/" + this.appConfigId);
            },
            back: function() {
                this.$router.push("/home/appconfiglist/" + this.appId);
            },
            add: function() {
                var that = this;
                httphelper.authedpostform(urls.appConfigAddComponentConfigUrl, {
                        "appConfigId": that.appConfigId,
                        "componentConfigId": that.componentConfigId
                    },
                    function (data) {
                        if (data) {
                            that.$notify.success("操作成功");
                            that.componentConfigId = 0;
                            that.getPager();
                        }
                    });
            },
            del: function(id) {
                var that = this;
                httphelper.authedpostform(urls.appConfigDeleteComponentConfigUrl, {
                        "appConfigId": that.appConfigId,
                        "componentConfigId": id
                    },
                    function (data) {
                        if (data) {
                            that.$notify.success("操作成功");
                            that.getPager();
                        }
                    });
            },
            Remove10002Config: function(call) {
                var that = this;
                httphelper.authedpostform(urls.componentConfigDeleteUrl, {
                        "id": that.componentConfigId_10002
                    },
                    function (data) {
                        call();
                    });
                httphelper.authedpostform(urls.appConfigDeleteComponentConfigUrl, {
                        "appConfigId": that.appConfigId,
                        "componentConfigId": that.componentConfigId_10002
                    },
                    function (data) {

                    });
            },
        }
    }
</script>

<style scoped>

</style>