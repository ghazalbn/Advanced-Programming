template<typename _Type>
class SaveVariableRef
{
    public:
        _Type* num;
        _Type nRef;
        SaveVariableRef(_Type &n)
        {
            *num = n;
            nRef = n;
        }
        ~SaveVariableRef<_Type>()
        {
            *num = nRef;
        }
};

template<typename _Type>
class SaveVariablePtr
{
    _Type* num;
    _Type nRef;
    public:
        SaveVariablePtr(_Type *n)
        {
            num = n;
            nRef = *n;
        }
        ~SaveVariablePtr<_Type>()
        {
            *num = nRef;
        }
};

