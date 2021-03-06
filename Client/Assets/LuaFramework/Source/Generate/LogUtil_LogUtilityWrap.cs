﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class LogUtil_LogUtilityWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(LogUtil.LogUtility), typeof(System.Object));
		L.RegFunction("Print", Print);
		L.RegFunction("PrintWarning", PrintWarning);
		L.RegFunction("PrintError", PrintError);
		L.RegFunction("New", _CreateLogUtil_LogUtility);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("LogEnable", get_LogEnable, set_LogEnable);
		L.RegVar("WarningEnable", get_WarningEnable, set_WarningEnable);
		L.RegVar("ErrorEnable", get_ErrorEnable, set_ErrorEnable);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateLogUtil_LogUtility(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				LogUtil.LogUtility obj = new LogUtil.LogUtility();
				ToLua.PushObject(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: LogUtil.LogUtility.New");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Print(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 1)
			{
				string arg0 = ToLua.CheckString(L, 1);
				LogUtil.LogUtility.Print(arg0);
				return 0;
			}
			else if (count == 2)
			{
				string arg0 = ToLua.CheckString(L, 1);
				LogUtil.LogColor arg1 = (LogUtil.LogColor)ToLua.CheckObject(L, 2, typeof(LogUtil.LogColor));
				LogUtil.LogUtility.Print(arg0, arg1);
				return 0;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: LogUtil.LogUtility.Print");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int PrintWarning(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string arg0 = ToLua.CheckString(L, 1);
			LogUtil.LogUtility.PrintWarning(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int PrintError(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string arg0 = ToLua.CheckString(L, 1);
			LogUtil.LogUtility.PrintError(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_LogEnable(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushboolean(L, LogUtil.LogUtility.LogEnable);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_WarningEnable(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushboolean(L, LogUtil.LogUtility.WarningEnable);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ErrorEnable(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushboolean(L, LogUtil.LogUtility.ErrorEnable);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_LogEnable(IntPtr L)
	{
		try
		{
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			LogUtil.LogUtility.LogEnable = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_WarningEnable(IntPtr L)
	{
		try
		{
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			LogUtil.LogUtility.WarningEnable = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_ErrorEnable(IntPtr L)
	{
		try
		{
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			LogUtil.LogUtility.ErrorEnable = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}
}

