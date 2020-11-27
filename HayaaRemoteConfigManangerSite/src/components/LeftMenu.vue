<template>
    <div>
        <el-row>
            <el-col>
                <el-menu default-active="1">
                    <el-submenu index="1">
                        <template slot="title">
                            <i class="el-icon-document"></i>
                            <span>远程配置</span>
                        </template>
                        <el-menu-item-group>
                             <el-menu-item index="1-1"><router-link to="/home/applist">程序管理</router-link></el-menu-item>
                            <el-menu-item index="1-2"><router-link to="/home/componentlist">组件管理</router-link></el-menu-item>
                            <el-menu-item index="1-3"><router-link to="/home/appcomponentlist">组件功能管理</router-link></el-menu-item>
                        </el-menu-item-group>
                    </el-submenu>

                </el-menu>
            </el-col>
        </el-row>
    </div>
</template>

<script>
    export default {
        name: "LeftMenu"
    }
</script>

<style scoped>

</style>