package mono.android.app;

public class ApplicationRegistration {

	public static void registerApplications ()
	{
				// Application and Instrumentation ACWs must be registered first.
		mono.android.Runtime.register ("ExampleLink.Droid.MainApplication, ExampleLink.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", crc640ded46436ebbf4f1.MainApplication.class, crc640ded46436ebbf4f1.MainApplication.__md_methods);
		
	}
}
