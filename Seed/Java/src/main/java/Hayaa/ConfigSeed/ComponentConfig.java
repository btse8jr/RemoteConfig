package Hayaa.ConfigSeed;

public class ComponentConfig {
    private Integer ID;
    private Integer ComponentConfigID;
    private Integer ComponentID;
    private String Content;
    private Integer Version;
    private String ComponentConfigTitle;

    public Integer getID() {
        return ID;
    }

    public void setID(int ID) {
        this.ID = ID;
    }

    public Integer getComponentConfigID() {
        return ComponentConfigID;
    }

    public void setComponentConfigID(Integer componentConfigID) {
        ComponentConfigID = componentConfigID;
    }

    public Integer getComponentID() {
        return ComponentID;
    }

    public void setComponentID(Integer componentID) {
        ComponentID = componentID;
    }

    public String getContent() {
        return Content;
    }

    public void setContent(String content) {
        Content = content;
    }

    public int getVersion() {
        return Version;
    }

    public void setVersion(int version) {
        Version = version;
    }

    public String getComponentConfigTitle() {
        return ComponentConfigTitle;
    }

    public void setComponentConfigTitle(String componentConfigTitle) {
        ComponentConfigTitle = componentConfigTitle;
    }


}
