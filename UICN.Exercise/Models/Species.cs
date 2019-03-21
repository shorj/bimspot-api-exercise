using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UICN.Api.Dto;
using UICN.Exercise.Models.Enums;

namespace UICN.Exercise.Models {
	internal class Species : BaseModel {
		#region Fields

		private static readonly ReadOnlyDictionary<string, ESpeciesCategory> StringCategoryToEnum =
			new ReadOnlyDictionary<string, ESpeciesCategory>(new Dictionary<string, ESpeciesCategory> {
				{"EX", ESpeciesCategory.Extinct},
				{"EW", ESpeciesCategory.ExtinctInTheWild},
				{"CR", ESpeciesCategory.CriticallyEndangered},
				{"EN", ESpeciesCategory.Endangered},
				{"VU", ESpeciesCategory.Vulnerable},
				{"NT", ESpeciesCategory.NearThreatened},
				{"LC", ESpeciesCategory.LeastConcern},
				{"DD", ESpeciesCategory.DataDeficient},
				{"NE", ESpeciesCategory.NotEvaluated},
			});

		#endregion

		#region Properties

		public int TaxonId { get; set; }

		public string KingdomName { get; set; }

		public string PhylumName { get; set; }

		public string ClassName { get; set; }

		public string OrderName { get; set; }

		public string FamilyName { get; set; }

		public string GenusName { get; set; }

		public string ScientificName { get; set; }

		public string InfraRank { get; set; }

		public string InfraName { get; set; }

		public string Population { get; set; }

		public ESpeciesCategory Category { get; set; }

		#endregion

		#region Constructors

		public Species() { }

		public Species(SpeciesDto fromDto) {
			TaxonId = fromDto.TaxonId;
			KingdomName = fromDto.KingdomName;
			PhylumName = fromDto.PhylumName;
			ClassName = fromDto.ClassName;
			OrderName = fromDto.OrderName;
			FamilyName = fromDto.FamilyName;
			GenusName = fromDto.GenusName;
			ScientificName = fromDto.ScientificName;
			InfraRank = fromDto.InfraRank;
			InfraName = fromDto.InfraName;
			Population = fromDto.Population;
			if(StringCategoryToEnum.TryGetValue(fromDto.Category, out ESpeciesCategory category)) {
				Category = category;
			} else {
				//todo: find full list of possible categories, e. g. "NA" is returned, but it does not exist in the The Red List category list
				//throw new ApplicationException($"Unknown Category = {fromDto.Category}");
				Category = ESpeciesCategory.Unknown;
			}
		}

		#endregion

		#region Methods

		public override string ToString() {
			return
				$"{nameof(TaxonId)} = {TaxonId}, {nameof(KingdomName)} = {KingdomName}, {nameof(PhylumName)} = {PhylumName}, {nameof(ClassName)} = {ClassName}, " +
				$"{nameof(OrderName)} = {OrderName}, {nameof(FamilyName)} = {FamilyName}, {nameof(GenusName)} = {GenusName}, {nameof(ScientificName)} = {ScientificName}, " +
				$"{nameof(InfraRank)} = {InfraRank}, {nameof(InfraName)} = {InfraName}, {nameof(Population)} = {Population}, {nameof(Category)} = {Category}";
		}

		#endregion
	}
}
