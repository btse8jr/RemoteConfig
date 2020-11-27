import axios from 'axios'
import qs from 'qs'
import Vue from 'vue'
import VueRouter from 'vue-router'
import {Notification} from 'element-ui';

const httphelper = {
    get(url, paramater, call, errcall) {
        axios.get(url, paramater)
            .then(function (rep) {
                if (call) {
                    if (rep.data.code == 0) {
                        call(rep.data.data)
                    } else {
                        if(rep.data.code==403){
                            Vue.$router.push("/login")
                        }else {
                            Notification.warning(rep.data.message)
                        }
                    }
                } else {
                    Notification.success("操作成功")
                }

            })
            .catch(function (rep) {
                Notification.error("网络异常")
            });
    },
    authedget(url, paramater, call, errcall) {
        paramater.token = "token";
        return this.get(url, paramater, call, errcall);
    },
    post(url, paramater, call, errcall) {
        axios.post(url, paramater,{withCredentials:true})
            .then(function (rep) {
                if (call) {
                    if (rep.data.code == 0) {
                        call(rep.data.data)
                    } else {
                        if(rep.data.code==403){
                            Vue.$router.push("/login")
                        }else {
                            Notification.warning(rep.data.message)
                        }
                    }
                } else {
                    Notification.success("操作成功")
                }

            })
            .catch(function (rep) {
                Notification.error("网络异常")
            });
    },
    authedpost(url, paramater, call, errcall) {
        paramater.token = "token";
        return this.post(url, paramater, call, errcall);
    },
    postform(url, data, call, errcall) {
        data = qs.stringify(data);
        return this.post(url, data, call, errcall);
    },
    authedpostform(url, data, call, errcall) {
        data.token = "token";
        return this.postform(url, data, call, errcall);
    }
}
export default httphelper