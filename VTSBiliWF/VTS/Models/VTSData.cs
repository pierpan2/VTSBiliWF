using System;

namespace VTS.Models {
    public class VTSMessageData
    {
        public string apiName = "VTubeStudioPublicAPI";
        public long timestamp;
        public string apiVersion = "1.0";
        public string requestID = Guid.NewGuid().ToString();
        public string messageType;
    }

    
    public class VTSErrorData : VTSMessageData{
         public VTSErrorData(){
            this.messageType = "APIError";
            this.data = new Data();
        }
        public Data data;

        
        public class Data {
            public ErrorID errorID;
            public string message;
        }
    }

    
    public class VTSStateData : VTSMessageData{
        public VTSStateData(){
            this.messageType = "APIStateRequest";
            this.data = new Data();
        }
        public Data data;

        
        public class Data{
            public bool active;
            public string vTubeStudioVersion;
            public bool currentSessionAuthenticated;
        }
    }

    public class VTSAuthData : VTSMessageData{
        public VTSAuthData(){
            this.messageType = "AuthenticationTokenRequest";
            this.data = new Data();
        }
        public Data data;

        public class Data {
            public string pluginName;
            public string pluginDeveloper;
            public string pluginIcon;
            public string authenticationToken;
            public bool authenticated;
            public string reason;
        }
    }

    
    public class VTSStatisticsData : VTSMessageData{
         public VTSStatisticsData(){
            this.messageType = "StatisticsRequest";
            this.data = new Data();
        }
        public Data data;

        
        public class Data {
            public long uptime;
		    public int framerate;
		    public int allowedPlugins;
		    public int connectedPlugins;
		    public bool startedWithSteam;
		    public int windowWidth;
		    public int windowHeight;
		    public bool windowIsFullscreen;
        }
    }

    
    public class VTSFolderInfoData : VTSMessageData{
         public VTSFolderInfoData(){
            this.messageType = "VTSFolderInfoRequestuest";
            this.data = new Data();
        }
        public Data data;

        
        public class Data {
            public string models;
		    public string backgrounds;
		    public string items;
		    public string config;
		    public string logs;
		    public string backup;
        }
    }

    
    public class VTSModelData {
        public bool modelLoaded;
        public string modelName;
        public string modelID;
        public string vtsModelName;
        public string vtsModelIconName;
    }

    
    public class ModelPosition{
        public float positionX = float.MinValue;
        public float positionY = float.MinValue;
        public float rotation = float.MinValue;
        public float size = float.MinValue;

    }

    
    public class VTSCurrentModelData : VTSMessageData{
         public VTSCurrentModelData(){
            this.messageType = "CurrentModelRequest";
            this.data = new Data();
        }
        public Data data;

        
        public class Data : VTSModelData{
		    public string live2DModelName;
		    public long modelLoadTime;
		    public long timeSinceModelLoaded;
		    public int numberOfLive2DParameters;
		    public int numberOfLive2DArtmeshes;
		    public bool hasPhysicsFile;
		    public int numberOfTextures;
		    public int textureResolution;
            public ModelPosition modelPosition;

        }
    }

    
    public class VTSAvailableModelsData : VTSMessageData{
         public VTSAvailableModelsData(){
            this.messageType = "AvailableModelsRequest";
            this.data = new Data();
        }
        public Data data;

        
        public class Data {
            public int numberOfModels;
            public VTSModelData[] availableModels;
        }
    }

    
    public class VTSModelLoadData : VTSMessageData{
        public VTSModelLoadData(){
            this.messageType = "ModelLoadRequest";
            this.data = new Data();
        }
        public Data data;

        
        public class Data {
            public string modelID;
        }
    }

    
    public class VTSMoveModelData : VTSMessageData{
        public VTSMoveModelData(){
            this.messageType = "MoveModelRequest";
            this.data = new Data();
        }
        public Data data;

        
        public class Data : ModelPosition {
            public float timeInSeconds;
            public bool valuesAreRelativeToModel;
        }
    }

    
    public class HotkeyData {
        public string name;
		public HotkeyAction type;
		public string file;
		public string hotkeyID;
    }

    
    public class VTSHotkeysInCurrentModelData : VTSMessageData{
        public VTSHotkeysInCurrentModelData(){
            this.messageType = "HotkeysInCurrentModelRequest";
            this.data = new Data();
        }
        public Data data;

        
        public class Data {
            public bool modelLoaded;
            public string modelName;
            public string modelID;
            public HotkeyData[] availableHotkeys;
        }
    }

    
    public class VTSHotkeyTriggerData : VTSMessageData{
        public VTSHotkeyTriggerData(){
            this.messageType = "HotkeyTriggerRequest";
            this.data = new Data();
        }
        public Data data;

        
        public class Data {
            public string hotkeyID;
        }
    }

    
    public class VTSArtMeshListData : VTSMessageData{
        public VTSArtMeshListData(){
            this.messageType = "ArtMeshListRequest";
            this.data = new Data();
        }
        public Data data;

        
        public class Data {
            public bool modelLoaded;
		    public int numberOfArtMeshNames;
		    public int numberOfArtMeshTags;
		    public string[] artMeshNames;
		    public string [] artMeshTags;
        }
    }

    // must be from 1-255
    
    public class ColorTint {
        public byte colorR;
        public byte colorG;
        public byte colorB;
        public byte colorA;

    }

    
    public class ArtMeshColorTint : ColorTint{
        public float mixWithSceneLightingColor = 1.0f;
    }

    
    public class ArtMeshMatcher {
        public bool tintAll = true;
        public int[] artMeshNumber;
        public string[] nameExact;
        public string[] nameContains;
        public string[] tagExact;
        public string[] tagContains;
    }

    
    public class VTSColorTintData : VTSMessageData{
        public VTSColorTintData(){
            this.messageType = "ColorTintRequest";
            this.data = new Data();
        }
        public Data data;

        
        public class Data {
            public ColorTint colorTint;
            public ArtMeshMatcher artMeshMatcher;
            public int matchedArtMeshes;
        }
    }

    
    public class ColorCapturePart : ColorTint {
        public bool active;
    }

    
    public class VTSSceneColorOverlayData : VTSMessageData{
        public VTSSceneColorOverlayData(){
            this.messageType = "SceneColorOverlayInfoRequest";
            this.data = new Data();
        }
        public Data data;

        
        public class Data {
            public bool active;
            public bool itemsIncluded;
            public bool isWindowCapture;
            public int baseBrightness;
            public int colorBoost;
            public int smoothing;
            public int colorOverlayR;
            public int colorOverlayG;
            public int colorOverlayB;
            public ColorCapturePart leftCapturePart;
            public ColorCapturePart middleCapturePart;
            public ColorCapturePart rightCapturePart;
        }
    }

    
    public class VTSFaceFoundData : VTSMessageData{
        public VTSFaceFoundData(){
            this.messageType = "FaceFoundRequest";
            this.data = new Data();
        }
        public Data data;

        
        public class Data {
            public bool found;
        }
    }

    
    public class VTSParameter {
        public string name;
        public string addedBy;
        public float value;
        public float min;
        public float max;
        public float defaultValue;
    }

    
    public class VTSInputParameterListData : VTSMessageData{
        public VTSInputParameterListData(){
            this.messageType = "InputParameterListRequest";
            this.data = new Data();
        }
        public Data data;

        
        public class Data {
            public bool modelLoaded;
            public string modelName;
            public string modelID;
            public VTSParameter[] customParameters;
            public VTSParameter[] defaultParameters;
        }
    }

    
    public class VTSParameterValueData : VTSMessageData{
        public VTSParameterValueData(){
            this.messageType = "ParameterValueRequest";
            this.data = new Data();
        }
        public Data data;

        
        public class Data : VTSParameter {}
    }

    
    public class VTSLive2DParameterListData : VTSMessageData{
        public VTSLive2DParameterListData(){
            this.messageType = "Live2DParameterListRequest";
            this.data = new Data();
        }
        public Data data;

        
        public class Data {
            public bool modelLoaded;
            public string modelName;
            public string modelID;
            public VTSParameter[] parameters;
        }
    }

    
    public class VTSCustomParameter {
        // 4-32 characters, alphanumeric
        public string parameterName;
        public string explanation;
        public float min;
        public float max;
        public float defaultValue;
    }

    
    public class VTSParameterCreationData : VTSMessageData{
        public VTSParameterCreationData(){
            this.messageType = "ParameterCreationRequest";
            this.data = new Data();
        }
        public Data data;

        
        public class Data : VTSCustomParameter {}
    }

    
    public class VTSParameterDeletionData : VTSMessageData{
        public VTSParameterDeletionData(){
            this.messageType = "ParameterDeletionRequest";
            this.data = new Data();
        }
        public Data data;

        
        public class Data {
            public string parameterName;
        }
    }

    
    public class VTSParameterInjectionValue{
        public string id;
        public float value = float.MinValue;
        public float weight = float.MinValue;
    }

    
    public class VTSInjectParameterData : VTSMessageData{
        public VTSInjectParameterData(){
            this.messageType = "InjectParameterDataRequest";
            this.data = new Data();
        }
        public Data data;

        
        public class Data {
            public VTSParameterInjectionValue[] parameterValues;
        }
    }

    
    public class ExpressionData{
        public string name;
		public string file;
		public bool active;
		public bool deactivateWhenKeyIsLetGo;
		public bool autoDeactivateAfterSeconds;
		public float secondsRemaining;
		public HotkeyData[] usedInHotkeys;
        public VTSParameter[] parameters;
    }

    
    public class VTSExpressionStateData : VTSMessageData{
        public VTSExpressionStateData(){
            this.messageType = "ExpressionStateRequest";
            this.data = new Data();
        }
        public Data data;

        
        public class Data {
            public bool details;
            public string expressionFile;
            public bool modelLoaded;
		    public string modelName;
		    public string modelID;
            public ExpressionData[] expressions;

        }
    }

    
    public class VTSExpressionActivationData : VTSMessageData{
        public VTSExpressionActivationData(){
            this.messageType = "ExpressionActivationRequest";
            this.data = new Data();
        }
        public Data data;

        
        public class Data {
		    public string expressionFile;
		    public bool active;
        }
    }


    
    public class VTSNDIConfigData : VTSMessageData{
        public VTSNDIConfigData(){
            this.messageType = "NDIConfigRequest";
            this.data = new Data();
        }
        public Data data;

        
        public class Data {
		    public bool setNewConfig;
		    public bool ndiActive;
		    public bool useNDI5;
		    public bool useCustomResolution;
		    public int customWidthNDI;
		    public int customHeightNDI;

        }
    }

    
    public class VTSStateBroadcastData : VTSMessageData{
        public VTSStateBroadcastData(){
            this.messageType = "VTubeStudioAPIStateBroadcast";
            this.data = new Data();
        }
        public Data data;

        
        public class Data {
            public bool active;
            public int port;
            public string instanceID;
            public string windowTitle;
        }
    }
}

