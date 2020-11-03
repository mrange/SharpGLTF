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
	/// glTF extension that defines the sheen material model.
	/// </summary>
	partial class MaterialSheen : ExtraProperties
	{
	
		private static readonly Vector3 _sheenColorFactorDefault = Vector3.Zero;
		private Vector3? _sheenColorFactor = _sheenColorFactorDefault;
		
		private TextureInfo _sheenColorTexture;
		
		private const Single _sheenRoughnessFactorDefault = 0;
		private const Single _sheenRoughnessFactorMinimum = 0;
		private const Single _sheenRoughnessFactorMaximum = 1;
		private Single? _sheenRoughnessFactor = _sheenRoughnessFactorDefault;
		
		private TextureInfo _sheenRoughnessTexture;
		
	
		protected override void SerializeProperties(Utf8JsonWriter writer)
		{
			base.SerializeProperties(writer);
			SerializeProperty(writer, "sheenColorFactor", _sheenColorFactor, _sheenColorFactorDefault);
			SerializePropertyObject(writer, "sheenColorTexture", _sheenColorTexture);
			SerializeProperty(writer, "sheenRoughnessFactor", _sheenRoughnessFactor, _sheenRoughnessFactorDefault);
			SerializePropertyObject(writer, "sheenRoughnessTexture", _sheenRoughnessTexture);
		}
	
		protected override void DeserializeProperty(string jsonPropertyName, ref Utf8JsonReader reader)
		{
			switch (jsonPropertyName)
			{
				case "sheenColorFactor": _sheenColorFactor = DeserializePropertyValue<Vector3?>(ref reader); break;
				case "sheenColorTexture": _sheenColorTexture = DeserializePropertyValue<TextureInfo>(ref reader); break;
				case "sheenRoughnessFactor": _sheenRoughnessFactor = DeserializePropertyValue<Single?>(ref reader); break;
				case "sheenRoughnessTexture": _sheenRoughnessTexture = DeserializePropertyValue<TextureInfo>(ref reader); break;
				default: base.DeserializeProperty(jsonPropertyName,ref reader); break;
			}
		}
	
	}

}
