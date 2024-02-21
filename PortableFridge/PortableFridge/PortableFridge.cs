using MSCLoader;
using UnityEngine;
using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;

namespace PortableFridge
{
    public class PortableFridge : Mod
    {
        public override string ID => "partabolifadriddggeee"; //Your mod ID (unique)
        public override string Name => "PortableFridge"; //You mod name
        public override string Author => "mcs"; //Your Username
        public override string Version => "1.4.8.8"; //Version
        public override string Description => "Your new portable fridge! You can take it far away!"; //Short description of your mod

        SettingsCheckBox Fridge;

        bool DoorOpened;

        private PlayMakerFSM electricbill;

        
        private GameObject breaker;

        
        private GameObject shockpoint;

        public override void ModSetup()
        {
            SetupFunction(Setup.OnLoad, Mod_OnLoad);
            SetupFunction(Setup.FixedUpdate, Mod_FixedUpdate);
        }

        public override void ModSettings()
        {
            Settings.AddHeader(this, "Fridge");
            Fridge = Settings.AddCheckBox(this, "fridge", "Make fridge bigger!", false);
        }

        private void Mod_OnLoad()
        {
            GameObject Teimo = GameObject.Find("STORE").transform.Find("TeimoInShop").gameObject;
            GameObject.Destroy(Teimo);
            GameObject Sound = GameObject.Find("MasterAudio").transform.Find("Teimo").gameObject;
            GameObject.Destroy(Sound);
            GameObject Fleetari = GameObject.Find("REPAIRSHOP").transform.Find("LOD/Office/Fleetari").gameObject;
            GameObject.Destroy(Fleetari);
            GameObject Uncle = GameObject.Find("YARD").transform.Find("UNCLE").gameObject;
            GameObject.Destroy(Uncle);
            GameObject Satsuma = GameObject.Find("SATSUMA(557kg, 248)").gameObject;
            GameObject.Destroy(Satsuma);
            GameObject Hayosiko = GameObject.Find("HAYOSIKO(1500kg, 250)").gameObject;
            GameObject.Destroy(Hayosiko);
            GameObject Ruscko = GameObject.Find("RCO_RUSCKO12(270)").gameObject;
            GameObject.Destroy(Ruscko);
            GameObject Kekmet = GameObject.Find("KEKMET(350-400psi)").gameObject;
            GameObject.Destroy(Kekmet);
            GameObject Gifu = GameObject.Find("GIFU(750/450psi)").gameObject;
            GameObject.Destroy(Gifu);
            GameObject TRAFFIC = GameObject.Find("TRAFFIC");
            GameObject.Destroy(TRAFFIC);
            GameObject Jani = GameObject.Find("NPC_CARS").transform.Find("Amikset/KYLAJANI").gameObject;
            GameObject.Destroy(Jani);
            GameObject Petteri = GameObject.Find("NPC_CARS").transform.Find("Amikset/KYLAJANI").gameObject;
            GameObject.Destroy(Jani);
            GameObject Kuski = GameObject.Find("NPC_CARS").transform.Find("KUSKI").gameObject;
            GameObject.Destroy(Kuski);
            GameObject Combine = GameObject.Find("JOBS").transform.Find("Farm/MachineHall/TargetCombine").gameObject;
            GameObject.Destroy(Combine);
            GameObject Train = GameObject.Find("TRAIN").gameObject;
            GameObject.Destroy(Train);
            GameObject Bus = GameObject.Find("NPC_CARS").transform.Find("BusSpawnRykipohja/BUS").gameObject;
            GameObject.Destroy(Bus);
            GameObject Soccer = GameObject.Find("SOCCER");
            GameObject.Destroy(Soccer);
            GameObject Uppers = GameObject.Find("STORE").transform.Find("LOD/ActivateBar/DrunksBar").gameObject;
            GameObject.Destroy(Uppers);
            GameObject Janitor = GameObject.Find("SOCCER").transform.Find("Janitor").gameObject;
            GameObject.Destroy(Janitor);
            GameObject boat = GameObject.Find("BOAT");
            GameObject.Destroy(boat);
            GameObject NPCBoat = GameObject.Find("GFX");
            GameObject.Destroy(NPCBoat);
            GameObject Bed = GameObject.Find("Bed");
            GameObject.Destroy(Bed);
            GameObject FlatBed = GameObject.Find("FLATBED");
            GameObject.Destroy(FlatBed);
            GameObject FernDale = GameObject.Find("FERNDALE(1630kg)");
            GameObject.Destroy(FernDale);
            GameObject NPCs = GameObject.Find("HUMANS");
            GameObject.Destroy(NPCs);
            GameObject SOFA = GameObject.Find("ITEMS").transform.Find("sofa(itemx)").gameObject;
            GameObject.Destroy(SOFA);
            GameObject JONNEZ = GameObject.Find("JONNEZ ES(Clone)");
            GameObject.Destroy(JONNEZ);
            GameObject JOBS = GameObject.Find("JOBS");
            GameObject.Destroy(JOBS);
            GameObject Settings = GameObject.Find("Systems").transform.Find("OptionsMenu").gameObject;
            GameObject.Destroy(Settings);
            GameObject CHURCH = GameObject.Find("PERAJARVI").transform.Find("CHURCH").gameObject;
            GameObject.Destroy(CHURCH);
            GameObject Gas1 = GameObject.Find("STORE").transform.Find("LOD/Pumps/GasolinePump98").gameObject;
            GameObject.Destroy(Gas1);
            GameObject Gas2 = GameObject.Find("STORE").transform.Find("LOD/Pumps/GasolinePumpD").gameObject;
            GameObject.Destroy(Gas2);
            GameObject Gas3 = GameObject.Find("STORE").transform.Find("LOD/Pumps/GasolinePumpPÖ").gameObject;
            GameObject.Destroy(Gas3);
            GameObject.Find("STORE").transform.Find("CLOSED").gameObject.SetActive(true);
            GameObject Products = GameObject.Find("STORE").transform.Find("LOD/PRODUCTS").gameObject;
            GameObject.Destroy(Products);
            try
            {
                Object.Destroy(GameObject.Find("YARD").transform.Find("Building/LIVINGROOM/Telephone/Logic").gameObject);
            }
            catch
            {
            }
            GameObject sun = GameObject.Find("MAP").transform.Find("SUN").gameObject;
            GameObject.Destroy(sun);
            GameObject.Find("PLAYER").transform.Find("PeeSound").gameObject.SetActive(true);
            GameObject.Find("PLAYER").transform.Find("Pivot/AnimPivot/Camera/FPSCamera/FPSCamera/HandCamera").gameObject.SetActive(false);
            GameObject.Find("PLAYER").transform.Find("Rain/Particle").gameObject.SetActive(false);

            this.shockpoint = GameObject.Find("YARD/Building/Dynamics/FuseTable").transform.GetChild(0).gameObject;
            this.breaker = GameObject.Find("YARD/Building/Dynamics/FuseTable/Fusetable/MainSwitch");
            this.electricbill = PlayMakerExtensions.GetPlayMaker(GameObject.Find("Systems/ElectricityBills"), "Data");

        }
        private void Mod_FixedUpdate()
        {
            float selected = Random.Range(0, 200000);
            if (selected <= 1 && selected != 0)
            {
                GameObject.Find("PLAYER").transform.Find("Pivot/AnimPivot/Camera/FPSCamera/FPSCamera/DeathBee").gameObject.SetActive(true);
            }
            float death = Random.Range(0, 300000);
            if (death <= 1 && death != 0)
            {
                GameObject.Find("Systems").transform.Find("Death").gameObject.SetActive(true);
            }
        }
    }
}
