


using BuilderPattern;

FishingRodBuilder fr = new FishingRodBuilder(4);
FishingRod fishingRodOnlyRod = fr.Build();
fr.GetCord(4);
FishingRod fishingRodWithCord =fr.Build();

fr.GetRings(4);
FishingRod fishingRodWhithRings= fr.Build();

