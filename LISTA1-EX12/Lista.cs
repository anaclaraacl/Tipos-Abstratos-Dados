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

    // Escreva um m�todo que retorne o n�mero de elementos armazenados na lista.
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
    // Escreva um m�todo que receba como par�metro uma Fila e adicione os itens desta fila na lista.
    public void AddItens(Fila f)
    {
        while (!f.vazia())
        {
            int valor = f.desenfileirar();
            this.inserir(valor);
        }
    }
    //Escreva um m�todo que retorne o n� com a maior chave. //+ GetMaior(): NoLista
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
    // Escreva um m�todo que calcule e retorne a m�dia das chaves armazenadas nos n�s. //+ CalcularMedia(): double
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
    Escreva um m�todo que troque as chaves entre os n�s da seguinte maneira: o primeiro receber� a chave do segundo, 
    o segundo receber� a do terceiro e assim sucessivamente, at� que o �ltimo receba a chave do primeiro.
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
    Escreva um m�todo denominado GetNo que retorne o n� correspondente ao n�mero passado como par�metro. 
    Caso o n� n�o exista, retorne null. Ex.: GetNo(0) dever� retornar o primeiro n� da lista, GetNo(1) 
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

    //Escreva um m�todo para empilhar e outro para desempilhar um elemento da lista.
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