package Hayaa.ConfigSeed;



public class AppLocalConfig {
    private String SeedServerUrl;
    private String LocalConfigDirectoryPath;
    private Boolean VirtualPath;
    private String AppConfigSentinelUrl;
    private String SecurityToken;
    private Integer AppID;
    private Integer AppInstanceID;
    private String AppConfigSolutionID;
    private Boolean RemoteConfigRoot;
    private Integer Version;

    public Boolean getVirtualPath() {
        return VirtualPath;
    }

    public void setVirtualPath(Boolean virtualPath) {
        VirtualPath = virtualPath;
    }

    public Boolean getRemote() {
        return Remote;
    }

    public void setRemote(Boolean remote) {
        Remote = remote;
    }

    private Boolean Remote;
    private String AppConfigFileName;

    public Integer getAppInstanceID() {
        return AppInstanceID;
    }

    public void setAppInstanceID(Integer appInstanceID) {
        AppInstanceID = appInstanceID;
    }

    public String getAppConfigSolutionID() {
        return AppConfigSolutionID;
    }

    public void setAppConfigSolutionID(String appConfigSolutionID) {
        AppConfigSolutionID = appConfigSolutionID;
    }

    public Boolean getRemoteConfigRoot() {
        return RemoteConfigRoot;
    }

    public void setRemoteConfigRoot(Boolean remoteConfigRoot) {
        RemoteConfigRoot = remoteConfigRoot;
    }

    public String getSeedServerUrl() {
        return SeedServerUrl;
    }

    public void setSeedServerUrl(String seedServerUrl) {
        SeedServerUrl = seedServerUrl;
    }

    public String getLocalConfigDirectoryPath() {
        return LocalConfigDirectoryPath;
    }

    public void setLocalConfigDirectoryPath(String localConfigDirectoryPath) {
        LocalConfigDirectoryPath = localConfigDirectoryPath;
    }

    public String getAppConfigSentinelUrl() {
        return AppConfigSentinelUrl;
    }

    public void setAppConfigSentinelUrl(String appConfigSentinelUrl) {
        AppConfigSentinelUrl = appConfigSentinelUrl;
    }

    public String getSecurityToken() {
        return SecurityToken;
    }

    public void setSecurityToken(String transfersSecurityKey) {
        SecurityToken = transfersSecurityKey;
    }

    public Integer getAppID() {
        return AppID;
    }

    public void setAppID(Integer appID) {
        AppID = appID;
    }


    public Integer getVersion() {
        return Version;
    }

    public void setVersion(Integer version) {
        Version = version;
    }



    public String getAppConfigFileName() {
        return AppConfigFileName;
    }

    public void setAppConfigFileName(String appConfigFileName) {
        AppConfigFileName = appConfigFileName;
    }


}
