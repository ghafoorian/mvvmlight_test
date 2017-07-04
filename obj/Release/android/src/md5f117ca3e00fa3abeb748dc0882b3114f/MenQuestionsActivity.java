package md5f117ca3e00fa3abeb748dc0882b3114f;


public class MenQuestionsActivity
	extends md5f19e992e7a4455b73413a9906d0cdf0a.BaseActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("XamarinDeveloper.Classes.MenQuestionsActivity, XamarinDeveloper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MenQuestionsActivity.class, __md_methods);
	}


	public MenQuestionsActivity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == MenQuestionsActivity.class)
			mono.android.TypeManager.Activate ("XamarinDeveloper.Classes.MenQuestionsActivity, XamarinDeveloper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
