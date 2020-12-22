package Hayaa.ConfigSeed;

import hayaa.basemodel.model.BaseData;

public class ComponentConfig extends BaseData {
    private Integer componentConfigId;
    private Integer componentId;
    private String content;
    private Integer version;
    private String componentConfigTitle;
    public Boolean isDefault;



    public Integer getComponentConfigId() {
        return componentConfigId;
    }

    public void setComponentConfigId(Integer componentConfigId) {
        this.componentConfigId = componentConfigId;
    }

    public Integer getComponentId() {
        return componentId;
    }

    public void setComponentId(Integer componentId) {
        this.componentId = componentId;
    }




    public String getContent() {
        return content;
    }

    public void setContent(String content) {
        this.content = content;
    }

    public Integer getVersion() {
        return version;
    }

    public void setVersion(Integer version) {
        this.version = version;
    }

    public String getComponentConfigTitle() {
        return componentConfigTitle;
    }

    public void setComponentConfigTitle(String componentConfigTitle) {
        this.componentConfigTitle = componentConfigTitle;
    }




}
