package Hayaa.ConfigSeed;

import hayaa.basemodel.model.BaseData;

import java.io.Serializable;
import java.util.List;
import java.util.UUID;

class AppConfig extends BaseData implements Serializable {
    private Integer ID;

    private String SolutionID;

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

    public String getSolutionID() {
        return SolutionID;
    }

    public void setSolutionID(String solutionID) {
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
