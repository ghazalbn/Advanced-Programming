package A4;

import org.junit.Test;

import A4.App.Config;

import static org.junit.Assert.*;

public class AppTest {

    @Test public void Config_Test() {
        Config c = Config.Cpu;
        c.ChangeValue(6);
        assertEquals(c.Value, 6);
        c.ChangeValue(0);
        assertEquals(c.Value, 0);
        assertEquals(Config.Cpu.ConfigValue,c.ConfigValue);
    }


    @Test public void ChooseBest_Test() {
         
        int graphic = Config.Graphic.ConfigValue;
        int ram = Config.Ram.ConfigValue;
        int cpu = Config.Cpu.ConfigValue;

        Config c = Config.Cpu;
        assertEquals("Not Bad", App.ChooseBest(c));

        c.ChangeValue(ram);
        assertEquals("Good", App.ChooseBest(c));

        c.ChangeValue(graphic);
        assertEquals("Not Bad", App.ChooseBest(c));

        c.ChangeValue(graphic|ram|cpu);
        assertEquals("Excellent", App.ChooseBest(c));

        c.ChangeValue(ram|cpu);
        assertEquals("Very Good", App.ChooseBest(c));

        c.ChangeValue(ram|graphic);
        assertEquals("Very Good", App.ChooseBest(c));

    }
    public int max(int a,int b,int c){
        if(a>=b && a>=c)
            return a;
        if(b>=a && b>=c)
            return b;
        else
            return c;
        
    }
}
