package Hayaa.ConfigSeed;

import java.util.List;
import java.util.UUID;

class AppConfig {
    private Integer ID;

    private UUID SolutionID;

    private String SolutionName;

    private String ConfigContent;
    private Integer Version;

    private List<ComponentConfig> Components;
    public int getID() {
        return ID;
    }

    public void setID(int ID) {
        this.ID = ID;
    }

    public UUID getSolutionID() {
        return SolutionID;
    }

    public void setSolutionID(UUID solutionID) {
        SolutionID = solutionID;
    }

    public String getSolutionName() {
        return SolutionName;
    }

    public void setSolutionName(String solutionName) {
        SolutionName = solutionName;
    }

    public String getConfigContent() {
        return ConfigContent;
    }

    public void setConfigContent(String configContent) {
        ConfigContent = configContent;
    }

    public int getVersion() {
        return Version;
    }

    public void setVersion(int version) {
        Version = version;
    }

    public List<ComponentConfig> getComponents() {
        return Components;
    }

    public void setComponents(List<ComponentConfig> components) {
        Components = components;
    }



}
