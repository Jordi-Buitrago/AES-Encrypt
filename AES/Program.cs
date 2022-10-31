int menu = 0;
while (menu != 3)
{

    {
        Console.WriteLine("[1] Encriptar");
        Console.WriteLine("[2] Desencriptar");
        Console.WriteLine("[3] Sortir");
        Console.Write("Introdueix l'opcio que vols realitzar: ");
        menu = int.Parse(Console.ReadLine());
        switch (menu)
        {
            case 1:
                Console.Write("Introdueix el nom del arxiu a encriptar: ");
                String nArxiu = Console.ReadLine();
                nArxiu = File.ReadAllText(nArxiu);
                Console.WriteLine("Introdueix la frase de pas: ");
                String pasPhrase = Console.ReadLine();
                String encriptat = AES.Xifrat.Encrypt(nArxiu, pasPhrase, "12345678");
                Console.WriteLine("El text desencriptat es aquest: " + encriptat);
                File.WriteAllText("encriptat.txt", encriptat);
                break;

            case 2:
                Console.Write("Introdueix el nom del arxiu a desencriptar: ");
                String nArxiuD = Console.ReadLine();
                nArxiu = File.ReadAllText(nArxiuD);
                if (nArxiuD != "encriptat.txt")
                {
                    Console.WriteLine("No existeix aquest arxiu, prova (encriptat.txt)");
                }
                else
                {
                    Console.WriteLine("Introdueix la frase de pas: ");
                    String pasPhraseD = Console.ReadLine();
                    String desencriptat = AES.Xifrat.Decrypt(nArxiu, pasPhraseD, "12345678");
                    Console.WriteLine("El text desencriptat es aquest: " + desencriptat);
                    File.WriteAllText("desencriptat.txt", desencriptat);
                }
                break;


            case 3:
                break;

        }


    }

}
