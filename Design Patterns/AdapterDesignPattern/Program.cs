


using AdapterDesignPattern.Models;

Compound compound = new Compound();
compound.Display();

Compound water = new RichCompound("water");
water.Display();

Compound benzene = new RichCompound("benzene");
benzene.Display();

Compound ethanol = new RichCompound("ethanol");
ethanol.Display();