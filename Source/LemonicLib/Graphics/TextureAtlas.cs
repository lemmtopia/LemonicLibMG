using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Principal;
using System.Xml;
using System.Xml.Linq;
using LemonicLib.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LemonicLib.Graphics;

public class TextureAtlas
{
    public Texture2D Texture;
    private Dictionary<string, TextureRegion> _regions;

    public TextureAtlas()
    {
        _regions = new Dictionary<string, TextureRegion>();
    }

    public TextureAtlas(Texture2D texture)
    {
        Texture = texture;
        _regions = new Dictionary<string, TextureRegion>();
    }

    public TextureRegion GetRegion(string name)
    {
        return _regions[name];
    }

    public void AddRegion(string name, TextureRegion region)
    {
        _regions.Add(name, region);
    }

    public bool RemoveRegion(string name)
    {
        return _regions.Remove(name);
    }

    public void Clear()
    {
        _regions.Clear();
    }

    public static TextureAtlas FromFile(ContentManager content, string fileName)
    {
        TextureAtlas atlas = new TextureAtlas();

        string filePath = Path.Combine(content.RootDirectory, fileName);
        Stream stream = TitleContainer.OpenStream(filePath);
        XmlReader reader = XmlReader.Create(stream);

        XDocument doc = XDocument.Load(reader);
        XElement root = doc.Root;

        string texturePath = root.Element("Texture").Value;
        atlas.Texture = content.Load<Texture2D>(texturePath);

        var regions = root.Element("Regions").Elements("Region");

        if (regions != null)
        {
            foreach (var region in regions)
            {
                string regionName = region.Attribute("name").Value;
                int regionX = int.Parse(region.Attribute("x").Value);
                int regionY = int.Parse(region.Attribute("y").Value);
                int regionWidth = int.Parse(region.Attribute("width").Value);
                int regionHeight = int.Parse(region.Attribute("height").Value);

                if (!string.IsNullOrEmpty(regionName))
                {
                    atlas.AddRegion(regionName, new TextureRegion(atlas.Texture, regionX, regionY, regionWidth, regionHeight));
                }
            }

        }

        return atlas;
    }
}