 Update Post SET 
                                      Title = @title,
                                      Content = @content,
                                      Category = @category,
                                      ImageLocation = @imageLocation,
                                      PublishDateTime = @publishDateTime
                                      WHERE Id = 1;