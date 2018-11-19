using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement
{
    class ClinicManagement
    {
        static void Main(string[] args)
        {
            //Variables
            string consult, imageRad, analyseSang, injection;
            const double taxes = 1.14;
            int nbPatients, agePatients;
            double patient, rep;
            double prixConsult = 0, prixRadio = 0, prixSang = 0, prixInjection = 0;
            double prixPatientAvecTaxes = 0, gainsClinique = 0;
            //Input
            Console.WriteLine("Entrez le nombre de patients que vous avez eu aujourd'hui."); //On demande à la clinique combien de patients ont reçus des services.
            nbPatients = Convert.ToInt16(Console.ReadLine());
            for (patient = 1; patient <= nbPatients; patient++)
            {
                Console.WriteLine("Quel est l'âge de votre patient " + patient + "?");
                agePatients = Convert.ToInt16(Console.ReadLine());
                if (agePatients < 12) //On déclare les prix de chaque services pour les patients âgés de moins de 12 ans.
                {
                    prixConsult = 25; prixRadio = 55; prixSang = 28; prixInjection = 0;
                }
                if ((agePatients >= 12) && (agePatients <= 18)) // On déclare les prix pour chaque services pour les patients âgés entre 12 et 18 ans.
                {
                    prixConsult = 32; prixRadio = 65; prixSang = 32; prixInjection = 13;
                }
                if ((agePatients >= 19) && (agePatients < 65)) // On déclare les prix pour chaque services pour les patients âgés entre 19 et 65 ans.
                {
                    prixConsult = 40; prixRadio = 70; prixSang = 40; prixInjection = 15;
                }
                if (agePatients >= 65) // On déclare les prix pour chaque services pour les patients âgés de plus de 65 ans.
                {
                    prixConsult = 30; prixRadio = 60; prixSang = 35; prixInjection = 12;
                }
                do //Boucle pour déterminer si le patient a eu une consultation.
                {
                    Console.WriteLine("Est-ce que le patient a eu une consultation : oui ou non");
                    consult = Console.ReadLine();
                } while ((consult != "oui") && (consult != "non"));
                if (consult == "non")
                {
                    prixConsult = 0;
                }
                do //Boucle pour déterminer si le patient a eu une image radio.
                {
                    Console.WriteLine("Est-ce que le patient a eu une image radio : oui ou non");
                    imageRad = Console.ReadLine();
                } while ((imageRad != "oui") && (imageRad != "non"));
                if (imageRad == "non")
                {
                    prixRadio = 0;
                }
                do //Boucle pour déterminer si le patient a eu une analyse de sang.
                {
                    Console.WriteLine("Est-ce que le patient a eu une analyse de sang : oui ou non");
                    analyseSang = Console.ReadLine();
                } while ((analyseSang != "oui") && (analyseSang != "non"));
                if (analyseSang == "non")
                {
                    prixSang = 0;
                }
                do //Boucle pour déterminer si le patient a eu une injection.
                {
                    Console.WriteLine("Est-ce que le patient a eu une injection : oui ou non");
                    injection = Console.ReadLine();
                } while ((injection != "oui") && (injection != "non"));
                if (injection == "non")
                {
                    prixInjection = 0;
                }
                if (injection == "oui")
                {
                    do
                    {
                        Console.WriteLine("Quel est la dose recue par le patient ? (1 pour 30 ml, 2 pour 50 ml, 3 pour 60 ml)");
                        rep = Convert.ToInt16(Console.ReadLine());
                        if (rep == 1)
                        {
                            prixInjection = (prixInjection * 30) / 30;
                        }
                        if (rep == 2)
                        {
                            prixInjection = (prixInjection * 50) / 30;
                        }
                        if (rep == 3)
                        {
                            prixInjection = (prixInjection * 60) / 30;
                        }
                    } while ((rep != 1) && (rep != 2) && (rep != 3));
                }
                if ((prixConsult > 0) && (prixRadio > 0)) //Rabais de 20% (avant taxes) sur l'image radio si pris en même temps qu'une consultation.
                {
                    prixRadio = prixRadio * 0.80;
                }
                double coutsTraitementsAvantTaxes = 0;
                coutsTraitementsAvantTaxes = prixConsult + prixRadio + prixSang + prixInjection;
                Console.WriteLine("Le coût total du patient " + patient + " avant taxes est de : " + coutsTraitementsAvantTaxes + "$");

                prixPatientAvecTaxes = coutsTraitementsAvantTaxes * taxes;

                if ((prixConsult > 0) && (prixRadio > 0) && (prixInjection > 0)) //Rabais de 20$ (après taxes) si le patient a eu en même temps une consultation, une image radio et une injection.
                {
                    prixPatientAvecTaxes = prixPatientAvecTaxes - 20;
                }
                Console.WriteLine("Le coût total du patient " + patient + " après taxes est de : " + prixPatientAvecTaxes + "$");

                gainsClinique = gainsClinique + prixPatientAvecTaxes;
                Console.WriteLine("Les gains de la clinique aujourd'hui sont de : " + gainsClinique + "$");
            }
        }
    }
}
