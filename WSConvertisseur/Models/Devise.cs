using System.ComponentModel.DataAnnotations;

namespace WSConvertisseur.Models {
    public class Devise {
		private int idDevise;
		
		private String? nomDevise;

		private Double tauxDevise;
        public Devise() {

        }

        public Devise(String? nomDevise, Double tauxDevise) {
            this.NomDevise = nomDevise;
            this.TauxDevise = tauxDevise;
        }

        public Devise(int idDevise, String? nomDevise, Double tauxDevise) {
            this.IDDevise = idDevise;
            this.NomDevise = nomDevise;
            this.TauxDevise = tauxDevise;
        }

		public int IDDevise {
			get { return idDevise; }
			set { idDevise = value; }
		}
        [Required]
        public String? NomDevise {
            get { return nomDevise; }
            set { nomDevise = value; }
        }
        public Double TauxDevise {
            get { return tauxDevise; }
            set { tauxDevise = value; }
        }

        public override bool Equals(object? obj) {
            return obj is Devise devise &&
                   this.idDevise == devise.idDevise &&
                   this.nomDevise == devise.nomDevise &&
                   this.tauxDevise == devise.tauxDevise;
        }

        public override string ToString() {
            return $"{this.NomDevise} | {this.TauxDevise}";
        }
    }
}
