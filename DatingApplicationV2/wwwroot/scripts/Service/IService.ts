export interface IService<TModel> {
    Get(id: string): TModel;
    Create(model: TModel): TModel;
    Update(model: TModel): TModel;
    Edit(model: TModel): void;
    Delete(id: string): void;
}

