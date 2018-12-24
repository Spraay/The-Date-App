interface IService<TModel> {
    Get(id: string);
    Create(model: TModel);
    Update(model: TModel);
    Edit(model: TModel);
    Delete(id: string);
}