using UnityEngine;
using System.Collections;

using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using System;
using System.Runtime.Serialization;
using System.Reflection;

//[Serializable ()]
[System.Serializable] 
public class Game_SaveLoad : ISerializable {

	public static bool savedData;
	public static string lastScene = "Bedroom (From Dream)";

	public static bool jayText = false;
	public static bool initialScene = true;
	public static bool benText = false;

	public static bool birthdayCard = false;
	public static bool present = false;
	public static bool openPresent = false;
	public static bool explanationLetter = false;
	public static bool giftBox = false;

	public static bool lakeVisited = false;
	public static bool map = false;
	public static bool boardwalk = false;
	public static bool medal = false;
	public static bool rock = false;
	public static bool plecs = false;
	public static bool jar = false;
	public static bool lakeFinished = false;

	public static bool parkVisited = false;
	public static bool picnicBench = false;
	public static bool polaroid = false;
	public static bool pond = false;
	public static bool kite = false;
	public static bool parkFinished = false;


	public Game_SaveLoad () {}

	public Game_SaveLoad (SerializationInfo info, StreamingContext ctxt)
	{
		savedData = (bool)info.GetValue("savedData", typeof(bool));
		lastScene = (string)info.GetValue("lastScene", typeof(string));

		jayText = (bool)info.GetValue("jayText", typeof(bool));
		initialScene = (bool)info.GetValue("initialScene", typeof(bool));
		benText = (bool)info.GetValue("benText", typeof(bool));

		birthdayCard = (bool)info.GetValue("birthdayCard", typeof(bool));
		present = (bool)info.GetValue("present", typeof(bool));
		openPresent = (bool)info.GetValue("openPresent", typeof(bool));
		explanationLetter = (bool)info.GetValue("explanationLetter", typeof(bool));
		giftBox = (bool)info.GetValue("giftBox", typeof(bool));

		lakeVisited = (bool)info.GetValue("lakeVisited", typeof(bool));
		map = (bool)info.GetValue("map", typeof(bool));
		boardwalk = (bool)info.GetValue("boardwalk", typeof(bool));
		medal = (bool)info.GetValue("medal", typeof(bool));
		rock = (bool)info.GetValue("rock", typeof(bool));
		plecs = (bool)info.GetValue("plecs", typeof(bool));
		jar = (bool)info.GetValue("jar", typeof(bool));
		lakeFinished = (bool)info.GetValue("lakeFinished", typeof(bool));

		parkVisited = (bool)info.GetValue("parkVisited", typeof(bool));
		picnicBench = (bool)info.GetValue("picnicBench", typeof(bool));
		polaroid = (bool)info.GetValue("polaroid", typeof(bool));
		pond = (bool)info.GetValue("pond", typeof(bool));
		kite = (bool)info.GetValue("kite", typeof(bool));
		parkFinished = (bool)info.GetValue("parkFinished", typeof(bool));
	}

	public void GetObjectData (SerializationInfo info, StreamingContext ctxt)
	{
		info.AddValue("savedData", savedData);
		info.AddValue("lastScene", lastScene);

		info.AddValue("jayText", jayText);
		info.AddValue("initialScene", initialScene);
		info.AddValue("benText", benText);

		info.AddValue("birthdayCard", birthdayCard);
		info.AddValue("present", present);
		info.AddValue("openPresent", openPresent);
		info.AddValue("explanationLetter", explanationLetter);
		info.AddValue("giftBox", giftBox);
	
		info.AddValue("lakeVisited", lakeVisited);
		info.AddValue("map", map);
		info.AddValue("boardwalk", boardwalk);
		info.AddValue("medal", medal);
		info.AddValue("rock", rock);
		info.AddValue("plecs", plecs);
		info.AddValue("jar", jar);
		info.AddValue("lakeFinished", lakeFinished);

		info.AddValue("parkVisited", parkVisited);
		info.AddValue("picnicBench", picnicBench);
		info.AddValue("polaroid", polaroid);
		info.AddValue("pond", pond);
		info.AddValue("kite", kite);
		info.AddValue("parkFinished", parkFinished);
	}

	public static void Check(){
		Debug.Log (Application.persistentDataPath);
		if (File.Exists (Application.persistentDataPath + "/savedGames.gd")) {
			savedData = true;
		}
		else
			savedData = false;
	}

			public static void Save () {
				Game_SaveLoad data = new Game_SaveLoad ();
				if (File.Exists (Application.persistentDataPath + "/savedGames.gd")) {
					Stream stream = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
					BinaryFormatter bformatter = new BinaryFormatter();
					bformatter.Binder = new VersionDeserializationBinder(); 
					bformatter.Serialize(stream, data);
					stream.Close();
				}
				else{
					Stream stream = File.Create (Application.persistentDataPath + "/savedGames.gd");
					BinaryFormatter bformatter = new BinaryFormatter();
					bformatter.Binder = new VersionDeserializationBinder(); 
					Debug.Log ("Writing Information");
					bformatter.Serialize(stream, data);
					stream.Close();
				}
			}
			
			public static void Load () {
				if(File.Exists(Application.persistentDataPath + "/savedGames.gd")){
					Game_SaveLoad data = new Game_SaveLoad ();
					Stream stream = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
					BinaryFormatter bformatter = new BinaryFormatter();
					bformatter.Binder = new VersionDeserializationBinder(); 
					data = (Game_SaveLoad)bformatter.Deserialize(stream);
					stream.Close();
				}
			}
}

public sealed class VersionDeserializationBinder : SerializationBinder 
{ 
	public override Type BindToType( string assemblyName, string typeName )
	{ 
		if ( !string.IsNullOrEmpty( assemblyName ) && !string.IsNullOrEmpty( typeName ) ) 
		{ 
			Type typeToDeserialize = null; 
			
			assemblyName = Assembly.GetExecutingAssembly().FullName; 
			
			// The following line of code returns the type. 
			typeToDeserialize = Type.GetType( String.Format( "{0}, {1}", typeName, assemblyName ) ); 
			
			return typeToDeserialize; 
		} 
		
		return null; 
	} 
}