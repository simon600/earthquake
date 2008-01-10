/* 
 * Author: Marcin Golebiowski
 * 
 */ 

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace TheEarthQuake.Players
{
    /// <summary>
    /// PlayerClasses. It holds and manages player classes, can load player classes definitions from an XML configuration file.
    /// </summary>
    public class PlayerClasses
    {
        // current player classes list
        private List<PlayerClass> playerClasses = new List<PlayerClass>();
    
        /// <summary>
        /// Load player classes from an XML file
        /// </summary>
        public PlayerClasses(string xmlFilePath)
        {


            // load xml
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFilePath);

            // get all nodes from XML file for player classes definitions
            XmlNodeList classNodes = doc.SelectNodes("/Classes/Class");
            //XmlNodeList classNodes = doc.SelectNodes("/Classes");

            //iterate over nodes
            foreach (XmlNode node in classNodes)
            {

               
                // create PlayerClass
                PlayerClass pClass = new PlayerClass();

                // read attributes  and assign values to properties
                pClass.Name = node.Attributes["Name"].InnerText;
                pClass.Speed = Convert.ToInt32(node.Attributes["Speed"].InnerText);
                pClass.MinePower = Convert.ToInt32(node.Attributes["MinePower"].InnerText);
                pClass.MineRange = Convert.ToInt32(node.Attributes["MineRange"].InnerText);
                pClass.MineType = Convert.ToInt32(node.Attributes["MineType"].InnerText);
                pClass.MaxHealth = Convert.ToInt32(node.Attributes["MaxHealth"].InnerText);
                pClass.SimultanousMines = Convert.ToInt32(node.Attributes["simultanousMines"].InnerText);
                pClass.MineDetonationTimeOffset = Convert.ToInt32(node.Attributes["mineDetonationTimeOffset"].InnerText);
                pClass.CanThrow = Convert.ToBoolean(node.Attributes["CanThrow"].InnerText);
                pClass.CanWalkMines = Convert.ToBoolean(node.Attributes["CanWalkMines"].InnerText);
                pClass.CanShiftMines = Convert.ToBoolean(node.Attributes["CanShiftMines"].InnerText);


                // read texture and logo path
                XmlNode textureNode = node.SelectSingleNode("Texture");
                pClass.TexturePath = textureNode.Attributes["Path"].InnerText;

                XmlNode logoNode = node.SelectSingleNode("Logo");
                pClass.LogoPath = logoNode.Attributes["Path"].InnerText;


                // add created PlayerClass to current player classes list
                playerClasses.Add(pClass);
            }
        }


        /// <summary>
        /// Returns all avaible player classes
        /// </summary>
        /// <returns></returns>
        public PlayerClass[] GetAll()
        {
            return playerClasses.ToArray();
        }
        
        /// <summary>
        /// Returns player class with given name. If there isn't any player class with given name then exception is thrown.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public PlayerClass GetPlayerClass(string name)
        {
            foreach (PlayerClass pClass in playerClasses)
            {
                if (pClass.Name == name)
                {
                    return pClass;
                }
            }
            throw new Exception("Player class is not found");
        }
    }
}
