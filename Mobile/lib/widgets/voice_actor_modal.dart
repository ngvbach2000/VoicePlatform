import 'package:flutter/material.dart';
import 'package:simple_shadow/simple_shadow.dart';
import '../constants/constants.dart';

class VoiceActorModal extends StatelessWidget {
  final String imageUrl;
  final String name;
  final String bio;
  final String gender;
  final String voiceType;
  final int pricePerOneWord;
  final double rating;

  const VoiceActorModal(
      {Key? key,
      required this.imageUrl,
      required this.name,
      required this.bio,
      required this.gender,
      required this.voiceType,
      required this.pricePerOneWord,
      required this.rating})
      : super(key: key);

  @override
  Widget build(BuildContext context) {
    double width = MediaQuery.of(context).size.width;

    return Container(
      margin: const EdgeInsets.symmetric(
        vertical: 5.0,
      ),
      padding: const EdgeInsets.symmetric(
        horizontal: 12.0,
        vertical: 7.0,
      ),
      decoration: BoxDecoration(
        borderRadius: BorderRadius.circular(25.0),
        color: Colors.white,
        boxShadow: [
          BoxShadow(
            color: Colors.grey.withOpacity(0.5),
            spreadRadius: 2.0,
            blurRadius: 3.0,
            offset: const Offset(2.0, 4.0),
          )
        ],
      ),
      child: Row(
        mainAxisAlignment: MainAxisAlignment.start,
        crossAxisAlignment: CrossAxisAlignment.start,
        children: <Widget>[
          Stack(
            children: <Widget>[
              Container(
                width: 90,
                decoration: const BoxDecoration(
                  color: Colors.white,
                ),
                alignment: Alignment.center,
                child: SimpleShadow(
                  opacity: 0.6,
                  color: Colors.grey,
                  offset: const Offset(0, 2.0),
                  sigma: 2.0,
                  child: ClipRRect(
                    borderRadius: BorderRadius.circular(25.0),
                    child: Image.network(
                      imageUrl,
                      fit: BoxFit.fill,
                    ),
                  ),
                ),
              ),
              const Positioned(
                right: 5.0,
                bottom: 10,
                child: Icon(
                  Icons.slow_motion_video_rounded,
                  color: appYellowColor,
                ),
              )
            ],
          ),
          DefaultTextStyle.merge(
            style: const TextStyle(
              fontSize: 11.0,
            ),
            child: Expanded(
              child: Container(
                margin: const EdgeInsets.fromLTRB(17.0, 0, 0, 0),
                child: Expanded(
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    mainAxisSize: MainAxisSize.min,
                    children: <Widget>[
                      Text(
                        name,
                        style: const TextStyle(fontWeight: FontWeight.bold),
                      ),
                      const SizedBox(
                        height: 2.0,
                      ),
                      Text(
                        bio,
                        style: const TextStyle(height: 1.3, letterSpacing: -0.165),
                        overflow: TextOverflow.ellipsis,
                        maxLines: 2,
                      ),
                      const SizedBox(
                        height: 2.0,
                      ),
                      Text(
                        'Gender: $gender',
                        overflow: TextOverflow.ellipsis,
                      ),
                      const SizedBox(
                        height: 2.0,
                      ),
                      Text(
                        'Voice type: $voiceType',
                        overflow: TextOverflow.ellipsis,
                      ),
                      Row(
                        mainAxisAlignment: MainAxisAlignment.end,
                        crossAxisAlignment: CrossAxisAlignment.end,
                        children: <Widget>[
                          Text(
                            '$pricePerOneWord VND/1 word',
                            style: const TextStyle(
                              fontWeight: FontWeight.bold,
                              fontSize: 11.0,
                            ),
                          ),
                          const SizedBox(
                            width: 10.0,
                          ),
                          RichText(
                            text: TextSpan(
                              children: [
                                TextSpan(
                                    text: '$rating ',
                                    style: TextStyle(
                                      color: Colors.black.withOpacity(0.7),
                                      fontSize: 11.0,
                                    )),
                                const WidgetSpan(
                                  child: Icon(
                                    Icons.star,
                                    size: 17.0,
                                    color: appYellowColor,
                                  ),
                                ),
                              ],
                            ),
                          )
                        ],
                      )
                    ],
                  ),
                ),
              ),
            ),
          ),
        ],
      ),
    );
  }
}
