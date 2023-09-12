package A4;

import java.util.Map;

import jdk.jshell.spi.ExecutionControl.NotImplementedException;

public class App {

    public enum Config
    {
        Graphic('1'),
        Ram('2'),
        Cpu('4');

        public int ConfigValue;
        public int Value;

        private Config(int configValue)
        {
        this.ConfigValue = configValue;
        this.Value = configValue;
        }
        public void ChangeValue(int value)
        {
            this.Value = value;
        }

    }


    public static String ChooseBest(Config c){
        if((c.Value & Config.Cpu.ConfigValue) == Config.Cpu.ConfigValue && (c.Value & Config.Ram.ConfigValue) == Config.Ram.ConfigValue && (c.Value & Config.Graphic.Value) == Config.Graphic.Value)
            return "Excellent";
        if((c.Value & Config.Ram.ConfigValue) == Config.Ram.ConfigValue && ((c.Value & Config.Graphic.Value) == Config.Graphic.Value || (c.Value & Config.Cpu.ConfigValue) == Config.Cpu.ConfigValue))
            return "Very Good";
        if((c.Value & Config.Ram.ConfigValue) == Config.Ram.ConfigValue)
            return "Good";
        if((c.Value & Config.Cpu.ConfigValue) == Config.Cpu.ConfigValue || (c.Value & Config.Graphic.Value) == Config.Graphic.Value)
            return "Not Bad";
        return null;
    }

    

    public static void main(String[] args) {
        
    }
}
