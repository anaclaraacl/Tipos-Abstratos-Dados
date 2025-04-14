public class No
{
    private int chave;
    private No? proximo;

    public No(int chave)
    {
        this.chave = chave;
        this.proximo = null;
    }

    public int getChave()
    {
        return chave;
    }
    public void setChave(int chave)
    {
        this.chave = chave;
    }

    public void setProximo(No? proximo)
    {
        this.proximo = proximo;
    }

    public No? getProximo()
    {
        return proximo;
    }
}