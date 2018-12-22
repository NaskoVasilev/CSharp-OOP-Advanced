using System;

namespace TrafficLights
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] lights = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());
            string[] orderedLights = new string[] { "Red", "Green", "Yellow" };


            for (int i = 0; i < n; i++)
            {
                ChangeLights(lights, orderedLights);
                Console.WriteLine(string.Join(" ", lights));
            }
        }

        private static void ChangeLights(string[] lights, string[] orderedLights)
        {
            for (int i = 0; i < lights.Length; i++)
            {
                string lightColor = lights[i];
                int indexOfColor = Array.IndexOf(orderedLights, lightColor);
                int nextIndex = (indexOfColor + 1) % orderedLights.Length;
                lights[i] = orderedLights[nextIndex];
            }
        }
    }
}
