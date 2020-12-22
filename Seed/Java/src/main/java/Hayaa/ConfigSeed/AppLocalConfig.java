package Hayaa.ConfigSeed;


import java.io.Serializable;

public class AppLocalConfig implements Serializable {
    private String seedServerUrl;
    private String localConfigDirectoryPath;
    private Boolean virtualPath;
    private String appConfigSentinelUrl;
    private String securityToken;
    private Integer appID;
    private Integer appInstanceID;
    private String appConfigSolutionID;
    private Boolean remoteConfigRoot;
    private Integer version;
    private Boolean remote;
    private String appConfigFileName;

    public String getSeedServerUrl() {
        return seedServerUrl;
    }

    public void setSeedServerUrl(String seedServerUrl) {
        this.seedServerUrl = seedServerUrl;
    }

    public String getLocalConfigDirectoryPath() {
        return localConfigDirectoryPath;
    }

    public void setLocalConfigDirectoryPath(String localConfigDirectoryPath) {
        this.localConfigDirectoryPath = localConfigDirectoryPath;
    }

    public Boolean getVirtualPath() {
        return virtualPath;
    }

    public void setVirtualPath(Boolean virtualPath) {
        this.virtualPath = virtualPath;
    }

    public String getAppConfigSentinelUrl() {
        return appConfigSentinelUrl;
    }

    public void setAppConfigSentinelUrl(String appConfigSentinelUrl) {
        this.appConfigSentinelUrl = appConfigSentinelUrl;
    }

    public String getSecurityToken() {
        return securityToken;
    }

    public void setSecurityToken(String securityToken) {
        this.securityToken = securityToken;
    }

    public Integer getAppID() {
        return appID;
    }

    public void setAppID(Integer appID) {
        this.appID = appID;
    }

    public Integer getAppInstanceID() {
        return appInstanceID;
    }

    public void setAppInstanceID(Integer appInstanceID) {
        this.appInstanceID = appInstanceID;
    }

    public String getAppConfigSolutionID() {
        return appConfigSolutionID;
    }

    public void setAppConfigSolutionID(String appConfigSolutionID) {
        this.appConfigSolutionID = appConfigSolutionID;
    }

    public Boolean getRemoteConfigRoot() {
        return remoteConfigRoot;
    }

    public void setRemoteConfigRoot(Boolean remoteConfigRoot) {
        this.remoteConfigRoot = remoteConfigRoot;
    }

    public Integer getVersion() {
        return version;
    }

    public void setVersion(Integer version) {
        this.version = version;
    }

    public Boolean getRemote() {
        return remote;
    }

    public void setRemote(Boolean remote) {
        this.remote = remote;
    }

    public String getAppConfigFileName() {
        return appConfigFileName;
    }

    public void setAppConfigFileName(String appConfigFileName) {
        this.appConfigFileName = appConfigFileName;
    }





}
