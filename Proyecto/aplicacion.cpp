#include "iostream"
#include "string"
using namespace std;

struct taza
{
    float precio;
    float cm;
};
struct camisa
{
    float precio;
    float cm;
};
struct estampado
{
    float cm;
};

taza tazas();
camisa camisas();
estampado estampados();

int main(void)
{
    int opcion;
    bool bandera = false;
    taza n;
    camisa n1;
    estampado n2;
    cout << "Aplicacion cantidad , precio.";
    cout << endl << endl;
do
{
    cout << " Menu de opciones." << endl;
    cout << "1)Taza." << endl;
    cout << "2)Camisa." << endl;
    cout << "3)Estampado." << endl;
    cout << "4)Salir" << endl;
    cin >> opcion;
    cin.ignore();
    switch (opcion)
    {
    case 1:
        n = tazas();
        break;
    case 2:
        n1 = camisas();
        break;
    case 3:
        n2 = estampados();
        break;
    case 4:
        bandera == true;
        break;
    
    default:
    cout << "La opcion que selecciono no existe." << endl;
        break;
    }
} while (bandera);

    
}
taza tazas()
{
taza n;
    cout << "Digite el precio de la taza." << endl;
    cin >> n.precio;
    cin.ignore();
    cout << "Digite la cantidad de cm que se utilizara." << endl;
    cin >> n.cm;
    cin.ignore();
    n.cm=n.cm*1;

    return n;

}
camisa camisas()
{
camisa n;
    cout << "Digite el precio de la camisa." << endl;
    cin >> n.precio;
    cin.ignore();
    cout << "Digite la cantidad de cm que se utilizara." << endl;
    cin >> n.cm;
    cin.ignore();
    n.cm=n.cm*1;

    return n;
}
estampado estampados()
{
estampado n;
    cout << "Digite la cantidad de cm que se utilizara." << endl;
    cin >> n.cm;
    cin.ignore();
    n.cm=n.cm*1;

    return n;
}