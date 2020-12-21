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
                            <template slot="title">基础设置</template>
                             <el-menu-item index="1-1"><router-link to="/home/applist" class="menuitem">程序管理</router-link></el-menu-item>
                            <el-menu-item index="1-2"><router-link to="/home/componentlist" class="menuitem">组件管理</router-link></el-menu-item>
                             <el-menu-item index="1-3"><router-link to="/home/appuserlist" class="menuitem">执行用户管理</router-link></el-menu-item>
                        </el-menu-item-group>
                    </el-submenu>
                    <el-submenu index="2">
                        <template slot="title">
                            <i class="el-icon-document"></i>
                            <span>代码工具</span>
                        </template>
                        <el-menu-item-group>
                            <template slot="title">代码管理</template>
                            <el-menu-item index="2-1"><router-link to="/home/codesolutionlist" class="menuitem">代码方案管理</router-link></el-menu-item>
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
.menuitem{
    size: 10px;
    color: black;
    text-decoration: none;
}
.menuitem:active{
    size: 10px;
    text-decoration: none;
}
</style>