using static System.Runtime.InteropServices.JavaScript.JSType;
//Michal Roček P2B, Program hledající prvočísla, 14. 12. 2023

//Horní hranice rozsahu, ve kterém prvočísla hledám
int upperBound = 100000000;

//pole pro prvočísla + pomocné proměnné
int[] primes = new int[upperBound];
primes[0] = 2; //dvojku si do pole dám předem, zbavím se tak jediného sudého prvočísla
int writeIndex = 1;

//pomocné proměnné pro hledání prvočísel
int index;
bool isPrime;

//hlavní program
/*
Hledání prvočísel:
* a) Smyčka prochází všechna lichá čísla do upperBound (sudá > 2 nemůžou být prvočíslem)
* b) Každé číslo zkusí vydělit pouze čísly menšími nebo rovnými odmocnině testovaného čísla, jeden z dělitelů čísla totiž musí být menší nebo roven odmocnině čísla
* c) Dělí pouze již nalezenými prvočísly, díky pravidlům dělitelnosti a základní větě algebry nemusí zkoušet složená čísla
*/
for (int i = 3; i < upperBound; i += 2) //a)
{
    //příprava pomocných proměnných
    index = 1; //na 0. pozici je 2, jelikož sudá čísla přeskakuji, numusím testovat
    isPrime = true;
    while (index < writeIndex && primes[index] <= (int)Math.Sqrt(i)) //b)
    {
        if (i % primes[index] == 0) //c)
        {
            isPrime = false; //nalezení dělitele => není prvočíslo
            break;
        }
        index++;
    }
    if (isPrime) //pokud je nalezeno prvočíslo, přidávám do pole
    {
        primes[writeIndex] = i;
        writeIndex++;
    }
}

//výpis všech nalezených prvočísel do konzole
/*for (int i = 0; i < writeIndex; i++)
{
    Console.WriteLine(primes[i]);
}*/

//výpis celkového počtu nalezených prvočísel
Console.WriteLine("Prime count: " + writeIndex);