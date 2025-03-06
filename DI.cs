
//DI Bad example
public class LightBulb {
    public void TurnOn() { Console.WriteLine("Light Bulb turned on");}
    public void TurnOff() { Console.WriteLine("Light Bulb turned off");}
}

public class SwitchBad {
    private LightBulb bulb;
    public SwitchBad() {
        bulb = new LightBulb();  //High level module depnds upon low level module
    }

    public void Toggle()
    {
        // Simple toggle logic
        if (bulb is null) return;
        if (isLightOn)
        {
            bulb.TurnOff();
            isLightOn = false;
        }
        else
        {
            bulb.TurnOn();
            isLightOn = true;
        }
    }
    private bool isLightOn = false;
}

//DI Good example
public interface ISwitchable
{
    void TurnOn();
    void TurnOff();
}

public class LightBulbGood : ISwitchable
{
    public void TurnOn() { Console.WriteLine("Light bulb turned on."); }
    public void TurnOff() { Console.WriteLine("Light bulb turned off."); }
}

public class Fan : ISwitchable
{
    public void TurnOn() { Console.WriteLine("Fan turned on."); }
    public void TurnOff() { Console.WriteLine("Fan turned off."); }
}

public class SwitchGood {
  private readonly ISwitchable device;
  public SwitchGood(ISwitchable device) {
    this.device = device;   //High level module depends upon abstraction
  }

  public void Toggle()
    {
        if (device is null) return;
        if (isDeviceOn)
        {
            device.TurnOff();
            isDeviceOn = false;
        }
        else
        {
            device.TurnOn();
            isDeviceOn = true;
        }
    }
    private bool isDeviceOn = false;
}