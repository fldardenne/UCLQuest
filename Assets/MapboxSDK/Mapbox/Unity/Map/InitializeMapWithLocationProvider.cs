namespace Mapbox.Unity.Map
{
	using System.Collections;
	using Mapbox.Unity.Location;
	using UnityEngine;
	using System; 

	public class InitializeMapWithLocationProvider : MonoBehaviour
	{
		[SerializeField]
		AbstractMap _map;

		ILocationProvider _locationProvider;

		const double PIx = 3.141592653589793;
		const double RADIUS = 6378.16;

		public GameObject notInLLNMeneu;

		/// <summary>
		/// Convert degrees to Radians
		/// </summary>
		/// <param name="x">Degrees</param>
		/// <returns>The equivalent in radians</returns>
		public static double Radians(double x)
		{
			return x * PIx / 180;
		}

		/// <summary>
		/// Calculate the distance between two places.
		/// </summary>
		/// <param name="lon1"></param>
		/// <param name="lat1"></param>
		/// <param name="lon2"></param>
		/// <param name="lat2"></param>
		/// <returns></returns>
		public static double DistanceBetweenPlaces(
			double lon1,
			double lat1,
			double lon2,
			double lat2)
		{
			double dlon = Radians(lon2 - lon1);
			double dlat = Radians(lat2 - lat1);

			double a = (Math.Sin(dlat / 2) * Math.Sin(dlat / 2)) + Math.Cos(Radians(lat1)) * Math.Cos(Radians(lat2)) * (Math.Sin(dlon / 2) * Math.Sin(dlon / 2));
			double angle = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
			return angle * RADIUS;
		}


		private float DegToRad(float deg)
		{
			float temp;
			temp = (deg * 3.14159265358979323846f) / 180.0f;
			temp = Mathf.Tan(temp);
			return temp;
		}
 
  		private float Distance_x(float lon_a, float lon_b, float lat_a, float lat_b)
		{
			float temp;
			float c;
			temp = (lat_b - lat_a);
			c = Mathf.Abs(temp * Mathf.Cos((lat_a + lat_b)) / 2);
			return c;
		}
 
		private float Distance_y(float lat_a, float lat_b)
		{
			float c = (lat_b - lat_a);
			return c;
		}
 
		private float Final_distance(float x, float y)
		{
			float c;
			c = Mathf.Abs(Mathf.Sqrt(Mathf.Pow(x, 2f) + Mathf.Pow(y, 2f))) * 6371;
			return c;
		}
 
		private float Calculate_Distance(float long_a, float lat_a,float long_b, float lat_b )
		{
			float a_long_r =DegToRad(long_a);
			float a_lat_r = DegToRad(lat_a);
			float p_long_r = DegToRad(long_b);
			float p_lat_r = DegToRad(lat_b);
			float dist_x = Distance_x(a_long_r, p_long_r, a_lat_r, p_lat_r);
			float dist_y = Distance_y(a_lat_r, p_lat_r);
			float total_dist = Final_distance(dist_x, dist_y);
			return total_dist;  
		}
    
		private void Awake()
		{
			// Prevent double initialization of the map. 
			_map.InitializeOnStart = false;
		}

		protected virtual IEnumerator Start()
		{
			yield return null;
			_locationProvider = LocationProviderFactory.Instance.DefaultLocationProvider;
			_locationProvider.OnLocationUpdated += LocationProvider_OnLocationUpdated; ;
		}

		void LocationProvider_OnLocationUpdated(Unity.Location.Location location)
		{
			_locationProvider.OnLocationUpdated -= LocationProvider_OnLocationUpdated;
			_map.Initialize(location.LatitudeLongitude, _map.AbsoluteZoom);


			double lln_center_lat = 50.6713085;
			double lln_center_long = 4.6119156;

			double currLatitude =  location.LatitudeLongitude[0];
			double currLongitude =  location.LatitudeLongitude[1];
			
			double distance = DistanceBetweenPlaces(lln_center_long, lln_center_lat, currLongitude,currLatitude);
			print(distance);
			if(distance > 1.5){
				print("PAS DANS LLN");
				notInLLNMeneu.SetActive(true);
			}else{
				print("DANS LLN");
				notInLLNMeneu.SetActive(false);
			}


		}
	}
}
