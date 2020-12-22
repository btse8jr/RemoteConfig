package hayaa.configseed.test;

import Hayaa.ConfigSeed.AppSeed;
import org.junit.Test;

public class ConfigSeedTest {
    @Test
    public void getConfig()
    {
        AppSeed.Instance().InitConfig();
    }
}
