using igxFormFieldsToolbar.Models;

namespace igxFormFieldsToolbar
{
    
    class startup
    {
        IGXSchema[] createSchemaObjects()
        {
            //idk if this is in any way correct but I just wanted to code something before leaving
            //50 should really be the number of schemas in the collection, but i dont like red squigglies
            //maybe the schema array can just be created after the querying begins
            //or maybe we don't need to return an array at all, who knows...........
            IGXSchema[] schemas = InitializeArray<IGXSchema>(50);

            return schemas;
        }

        T[] InitializeArray<T>(int length) where T : new()
        {
            T[] array = new T[length];
            for (int i = 0; i < length; ++i)
            {
                array[i] = new T();
            }

            return array;
        }
    

    }
}