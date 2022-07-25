namespace UFO.Internals;

internal static class UfoOrientationSensor
{
	internal static event EventHandler<OrientationSensorChangedEventArgs> OrientationChanged;

	internal static void Start()
	{
		if (OrientationSensor.IsMonitoring)
		{
			return;
		}

		OrientationSensor.Start(SensorSpeed.UI);
		OrientationSensor.ReadingChanged += OrientationSensor_ReadingChanged;
	}

	internal static void Stop()
	{
		OrientationSensor.Stop();
		OrientationSensor.ReadingChanged -= OrientationSensor_ReadingChanged;
	}

	internal static void OrientationSensor_ReadingChanged(object sender, OrientationSensorChangedEventArgs e)
	{
		OrientationChanged?.Invoke(null, e);
	}
}