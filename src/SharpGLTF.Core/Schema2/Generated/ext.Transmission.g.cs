// <auto-generated/>

//------------------------------------------------------------------------------------------------
//      This file has been programatically generated; DON´T EDIT!
//------------------------------------------------------------------------------------------------

#pragma warning disable SA1001
#pragma warning disable SA1027
#pragma warning disable SA1028
#pragma warning disable SA1121
#pragma warning disable SA1205
#pragma warning disable SA1309
#pragma warning disable SA1402
#pragma warning disable SA1505
#pragma warning disable SA1507
#pragma warning disable SA1508
#pragma warning disable SA1652

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Text.Json;

namespace SharpGLTF.Schema2
{
	using Collections;

	/// <summary>
	/// glTF extension that defines the optical transmission of a material.
	/// </summary>
	partial class MaterialTransmission : ExtraProperties
	{
	
		private const Double _transmissionFactorDefault = 0;
		private const Double _transmissionFactorMinimum = 0;
		private const Double _transmissionFactorMaximum = 1;
		private Double? _transmissionFactor = _transmissionFactorDefault;
		
		private TextureInfo _transmissionTexture;
		
	
		protected override void SerializeProperties(Utf8JsonWriter writer)
		{
			base.SerializeProperties(writer);
			SerializeProperty(writer, "transmissionFactor", _transmissionFactor, _transmissionFactorDefault);
			SerializePropertyObject(writer, "transmissionTexture", _transmissionTexture);
		}
	
		protected override void DeserializeProperty(string jsonPropertyName, ref Utf8JsonReader reader)
		{
			switch (jsonPropertyName)
			{
				case "transmissionFactor": _transmissionFactor = DeserializePropertyValue<Double?>(ref reader); break;
				case "transmissionTexture": _transmissionTexture = DeserializePropertyValue<TextureInfo>(ref reader); break;
				default: base.DeserializeProperty(jsonPropertyName,ref reader); break;
			}
		}
	
	}

}
