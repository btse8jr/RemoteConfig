package Hayaa.ConfigSeed;

import java.util.UUID;

class AppLocalConfig {
    private String SeedServerUrl;
    private  String LocalConfigDirectoryPath;
    private Boolean IsVirtualPath;
    private String AppConfigSentinelUrl;
    private String SecurityToken;
    private Integer AppID;
    private UUID AppConfigID;
    private Integer Version;
    private  Boolean IsRemote;
    private String AppConfigFileName;
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

    public Boolean getVirtualPath() {
        return IsVirtualPath;
    }

    public void setVirtualPath(Boolean virtualPath) {
        IsVirtualPath = virtualPath;
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

    public UUID getAppConfigID() {
        return AppConfigID;
    }

    public void setAppConfigID(UUID appConfigID) {
        AppConfigID = appConfigID;
    }

    public Integer getVersion() {
        return Version;
    }

    public void setVersion(Integer version) {
        Version = version;
    }

    public Boolean getRemote() {
        return IsRemote;
    }

    public void setRemote(Boolean remote) {
        IsRemote = remote;
    }

    public String getAppConfigFileName() {
        return AppConfigFileName;
    }

    public void setAppConfigFileName(String appConfigFileName) {
        AppConfigFileName = appConfigFileName;
    }


}
