using UnityEngine;
using UnityEditor;
 
/// <summary>  
/// Extension class to expose variables for script custom template use
/// </summary>
public class KeywordReplace : UnityEditor.AssetModificationProcessor {
 
    public static void OnWillCreateAsset ( string path ) {
        
        path = path.Replace( ".meta", "" );
        
        var index = path.LastIndexOf( "." );
        var file = path.Substring( index );
        
        if ( file != ".cs" ) return;
        index = Application.dataPath.LastIndexOf( "Assets" );
        path = Application.dataPath.Substring( 0, index ) + path;
        file = System.IO.File.ReadAllText( path );
 
        file = file.Replace( "#CREATIONDATE#", System.DateTime.Now + "" );
        file = file.Replace( "#PROJECTNAME#", PlayerSettings.productName );
        file = file.Replace( "#AUTHOR#", PlayerSettings.companyName );
 
        System.IO.File.WriteAllText( path, file );
        AssetDatabase.Refresh();
    }
}