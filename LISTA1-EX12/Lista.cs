public class Lista
{
    private No? primeiro;
    private No? ultimo;

    public Lista()
    {
        this.primeiro = null;
        this.ultimo = null;
    }

    public bool vazia()
    {
        return this.primeiro == null;
    }

    public void limpar() {
        this.primeiro = this.ultimo = null;
    }

    public void inserir(int chave)
    {
        No novo = new No(chave);
        if (this.vazia())
        {
            this.primeiro = novo;
        }
        else
        {
            this.ultimo?.setProximo(novo);
        }
        this.ultimo = novo;
    }

    public bool remover(int chave)
    {
        No? aux = this.primeiro;
        No? anterior = null;

        while (aux != null && aux.getChave() != chave)
        {
            anterior = aux;
            aux = aux.getProximo();
        }

        if (aux == null)
        {
            return false;
        }

        if (anterior == null)
        {
            this.primeiro = aux.getProximo();
        }
        else
        {
            anterior.setProximo(aux.getProximo());
        }
        aux.setProximo(null);

        if (aux == this.ultimo)
        {
            this.ultimo = anterior;
        }
        return true;
    }

    public void imprimir()
    {
        string valores = "";
        No? aux = this.primeiro;

        while (aux != null)
        {
            valores += aux.getChave() + ", ";
            aux = aux.getProximo();
        }

        Console.WriteLine("[ {0} ]",
            valores.Length > 0 ?
            valores.Substring(0, valores.Length - 2) :
            valores
        );
    }

    public int procurar(int chave) {
        No? aux = this.primeiro;
        int indice = 0;
        while (aux != null) {
            if (aux.getChave() == chave) {
                return indice;
            }
            indice++;
            aux = aux.getProximo();
        }
        return -1;
    }

    // Escreva um método que retorne o número de elementos armazenados na lista.
    public int GetTamanho()
    {
        int cont = 0;
        No aux = primeiro;
        while (aux != null)
        {
            aux = aux.getProximo();
            cont++;
        }
        return cont;
    }
    // Escreva um método que receba como parâmetro uma Fila e adicione os itens desta fila na lista.
    public void AddItens(Fila f)
    {
        while (!f.vazia())
        {
            int valor = f.desenfileirar();
            this.inserir(valor);
        }
    }
    //Escreva um método que retorne o nó com a maior chave. //+ GetMaior(): NoLista
    public No GetMaior()
    {
        No aux = primeiro;
        No maior  = primeiro;
        while (aux != null)
        {
            if(aux.getChave() > maior.getChave())
            {
                maior = aux;
            } 
            aux = aux.getProximo();
        }
        return maior;
    }
    // Escreva um método que calcule e retorne a média das chaves armazenadas nos nós. //+ CalcularMedia(): double
    public double CalcularMedia()
    {
        int cont = 0;
        double soma = 0;
        No aux = primeiro;
        while (aux != null)
        {
            soma += aux.getChave();
            aux = aux.getProximo();
            cont++;
        }
        return soma / cont;
    }
    /*
    Escreva um método que troque as chaves entre os nós da seguinte maneira: o primeiro receberá a chave do segundo, 
    o segundo receberá a do terceiro e assim sucessivamente, até que o último receba a chave do primeiro.
    */
    public void TrocarChaves()
    {
        if (primeiro == null || primeiro.getProximo() == null)
            return; 

        int chavePrimeiro = primeiro.getChave();
        No? aux = primeiro;
        while (aux.getProximo() != null)
        {
            aux.setChave(aux.getProximo().getChave());
            aux = aux.getProximo();
        }
        aux.setChave(chavePrimeiro);
    }
    /*
    Escreva um método denominado GetNo que retorne o nó correspondente ao número passado como parâmetro. 
    Caso o nó não exista, retorne null. Ex.: GetNo(0) deverá retornar o primeiro nó da lista, GetNo(1) 
    o segundo e assim sucessivamente.
    */
    public No GetNo(int indice)
    {
        int cont = 0;
        No? aux = primeiro;
        while(aux != null && indice != cont)
        {
            aux = aux.getProximo();
            cont++;
        }
        return aux;
    }

    //Escreva um método para empilhar e outro para desempilhar um elemento da lista.
    public void Empilhar(int chave)
    {
        No novo = new No(chave);
        novo.setProximo(primeiro);  
        primeiro = novo;           

        if (ultimo == null)        
            ultimo = novo;
    }
    public int? Desempilhar()
    {
        if (vazia()) return null;

        int chave = primeiro.getChave();
        primeiro = primeiro.getProximo();

        if (primeiro == null)     
            ultimo = null;

        return chave;
    }

}