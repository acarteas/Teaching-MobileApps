//specify where credentials to load are located  credpath is the name of our service key
string credpath = "google_api.json";
Google.Apis.uth.OAuth2.GoogleCredential credential;

//load cert into the credential
using (var stream = Assets.Open(credpath)){
	credential = Google.Apis.Auth.OAuth2.GoogleCredential.FromStream(stream);

}

//scope it; what can this crediential be used FOR
crediential = crediential.CreateScoped(
	Google.Apis.Vision.v1.VisionService.Scope.CloudPlatform);



var client = new Google.Apis.Vision.v1.VisionService(
	new BaseClientService.Initializer()
	{
		//application name must equal the id of the project, from google dev console.
		ApplicationName = "cs480p3",
		HttpClientintializer = credential
	}
	);

//tell google that we want to perform feature analysis
var request = new AnnotateImageRequest();
request.Image = new Image();

using(var stream = new System.IO.MemoryStream()){
	bitmap.Compress(Android.Graphics.Bitmap.CompressFormat.Jpeg, 85, stream);
	request.Image.Content = System.Convert.ToBase64String(stream.ToArray()
	);
}


//now we want to do feature detection
request.Features = new list<Feature>();
request.Features.Add(new Feature() {Type = "LABEL_DETECTION"});

//can add moreo requests for additional features around here.

//add to list of items to send to google
var batch = new BatchAnnotateImagesRequest();
batch.Requests = new List<AnnotateImageRequest>();
batch.Requests.Add(request);

//finally make the call to send the request out
var apiResult = client.Images.Annotate(batch).Execute();


//loop through the results
List<string> tags = new List<string>();
foreach (var item in apiResult.Responses[0].labelAnnotations){
	tags.Add(item.Description);
}



