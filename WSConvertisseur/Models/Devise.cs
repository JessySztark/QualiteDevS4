namespace WSConvertisseur.Models {
    public class Devise {
		private int idDevise;
		
		private String? nomDevise;

		private Double tauxDevise;
        public Devise() {

        }

		public int IDDevise {
			get { return idDevise; }
			set { idDevise = value; }
		}
        public String? NomDevise {
            get { return nomDevise; }
            set { nomDevise = value; }
        }
        public Double TauxDevise {
            get { return tauxDevise; }
            set { tauxDevise = value; }
        }
    }
}
