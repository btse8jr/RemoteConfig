<template>
    <div style="margin-left: 15px">
        <div>
            <el-form ref="form" label-width="80px">
                <el-form-item label="活动名称" size="small"  style="float: left">
                    <el-input style="width: 120px;"></el-input>
                </el-form-item>
                <el-form-item label="活动名称" size="small" >
                    <el-input style="width: 120px;"></el-input>
                </el-form-item>
                <el-form-item label="活动时间" >
                    <el-col :span="3">
                        <el-form-item prop="date1">
                            <el-date-picker type="date" placeholder="选择日期" style=" width: 120px"></el-date-picker>
                        </el-form-item>
                    </el-col>
                    <el-col class="line" :span="1">--</el-col>
                    <el-col :span="3">
                        <el-form-item prop="date2">
                            <el-time-picker type="fixed-time" placeholder="选择时间" style=" width: 120px"></el-time-picker>
                        </el-form-item>
                    </el-col>
                </el-form-item>
                <el-form-item size="small">
                    <el-button type="primary">搜索</el-button>
                    <el-button>重置</el-button>
                </el-form-item>
            </el-form>
        </div>
        <div style="float: right"><el-button @click="handleAdd">添加</el-button></div>
        <el-table :data="tableData">
            <el-table-column
                    label="日期"
                    width="180">
                <template slot-scope="scope">
                    <i class="el-icon-time"></i>
                    <span>{{ scope.row.date }}</span>
                </template>
            </el-table-column>
            <el-table-column
                    label="姓名"
                    width="180">
                <template slot-scope="scope">
                    <el-popover trigger="hover" placement="top">
                        <p>姓名: {{ scope.row.name }}</p>
                        <p>住址: {{ scope.row.address }}</p>
                        <div slot="reference" class="name-wrapper">
                            <el-tag size="medium">{{ scope.row.name }}</el-tag>
                        </div>
                    </el-popover>
                </template>
            </el-table-column>
            <el-table-column label="操作">
                <template slot-scope="scope">
                    <el-button
                            size="mini"
                            @click="handleEdit(scope.$index, scope.row)">编辑
                    </el-button>
                    <el-button
                            size="mini"
                            type="danger"
                            @click="handleDelete(scope.$index, scope.row)">删除
                    </el-button>
                </template>
            </el-table-column>
        </el-table>
    </div>
</template>

<script>
    export default {
        name: "List",
        data: function() {
            return {
                tableData: [{
                    date: '2016-05-02',
                    name: '王小虎',
                    address: '上海市普陀区金沙江路 1518 弄'
                }, {
                    date: '2016-05-04',
                    name: '王小虎',
                    address: '上海市普陀区金沙江路 1517 弄'
                }, {
                    date: '2016-05-01',
                    name: '王小虎',
                    address: '上海市普陀区金沙江路 1519 弄'
                }, {
                    date: '2016-05-03',
                    name: '王小虎',
                    address: '上海市普陀区金沙江路 1516 弄'
                }, {
                    date: '2016-05-04',
                    name: '王小虎',
                    address: '上海市普陀区金沙江路 1517 弄'
                }]
            }
        },
        methods: {
            handleAdd: function(){
                this.$router.push("/home/edit");
            },
            handleEdit: function(index, row) {
                console.log(index, row);
            },
            handleDelete: function(index, row) {
                console.log(index, row);
            }
        }
    }
</script>

<style scoped>

</style>